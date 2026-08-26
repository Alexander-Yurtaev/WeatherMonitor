using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using System.Net;
using WeatherMonitor.Application;
using WeatherMonitor.Application.Handlers;
using WeatherMonitor.Application.Requests;
using WeatherMonitor.Domain.Data;
using WeatherMonitor.Domain.Dto;
using WeatherMonitor.Tests.Helpers;

namespace WeatherMonitor.Tests;

public class WeatherHandlersTests
{
    [Fact]
    public async Task WeatherHandlers_Correct()
    {
        // Arrange
        var request = new GetWeatherRequest(10, 20);
        var expectedDto = TestHelpers.GetWeatherDto();
        var expectedData = TestHelpers.GetWeatherData();

        var httpMessageHandler = new FakeHttpMessageHandler(TestHelpers.GetJsonData());
        var httpClient = new HttpClient(httpMessageHandler)
        {
            BaseAddress = new Uri("http://test")
        };

        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        httpClientFactoryMock
            .Setup(x => x.CreateClient(It.IsAny<string>()))
            .Returns(httpClient);

        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(x => x.Map<WeatherData>(It.IsAny<WeatherDto>()))
            .Returns(expectedData);

        var weatherApiOptionsMock = new Mock<IOptions<WeatherApiOptions>>();
        weatherApiOptionsMock.Setup(x => x.Value)
            .Returns(new WeatherApiOptions { ApiKey = "API-KEY" });

        var handler = new WeatherHandlers(httpClientFactoryMock.Object, mapperMock.Object, weatherApiOptionsMock.Object);

        // Act

        var response = await handler.Handle(request, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.Data.Should().NotBeNull();
        response.ErrorMessage.Should().BeEmpty();
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest, "Bad Request")]
    [InlineData(HttpStatusCode.Unauthorized, "Unauthorized")]
    [InlineData(HttpStatusCode.Forbidden, "Forbidden")]
    [InlineData(HttpStatusCode.NotFound, "Not Found")]
    [InlineData(HttpStatusCode.InternalServerError, "Internal Server Error")]
    [InlineData(HttpStatusCode.ServiceUnavailable, "Service Unavailable")]
    [InlineData(HttpStatusCode.TooManyRequests, "Too Many Requests")]
    public async Task WeatherHandlers_WithError(HttpStatusCode errorCode, string errorContent)
    {
        // Arrange
        var request = new GetWeatherRequest(10, 20);
        var expectedDto = TestHelpers.GetWeatherDto();
        var expectedData = TestHelpers.GetWeatherData();

        var httpMessageHandler = new FailHttpMessageHandler(errorCode, errorContent);
        var httpClient = new HttpClient(httpMessageHandler)
        {
            BaseAddress = new Uri("http://test")
        };

        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        httpClientFactoryMock
            .Setup(x => x.CreateClient(It.IsAny<string>()))
            .Returns(httpClient);

        var mapperMock = new Mock<IMapper>();
        //mapperMock.Setup(x => x.Map<WeatherData>(It.IsAny<WeatherDto>()))
        //    .Returns(expectedData);

        var weatherApiOptionsMock = new Mock<IOptions<WeatherApiOptions>>();
        weatherApiOptionsMock.Setup(x => x.Value)
            .Returns(new WeatherApiOptions { ApiKey = "API-KEY" });

        var handler = new WeatherHandlers(httpClientFactoryMock.Object, mapperMock.Object, weatherApiOptionsMock.Object);

        // Act

        var response = await handler.Handle(request, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.Data.Should().BeNull();
        response.ErrorMessage.Should().NotBeEmpty();
    }
}
