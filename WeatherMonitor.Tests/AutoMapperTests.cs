using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using WeatherMonitor.Application;
using WeatherMonitor.Domain.Data;
using WeatherMonitor.Domain.Dto;
using WeatherMonitor.Tests.Helpers;

namespace WeatherMonitor.Tests;

public class AutoMapperTests
{
    [Fact]
    public void AssertConfigurationIsValid()
    {
        // Arrange
        var config = CreateConfig();


        // Act
        // Assert
        config.AssertConfigurationIsValid();
    }

    [Fact]
    public void Map_WeatherDto_To_WeatherData_Should_Be_Correct()
    {
        // Arrange
        var config = CreateConfig();
        var mapper = config.CreateMapper();

        var dto = TestHelpers.GetWeatherDto();

        // Act
        var data = mapper.Map<WeatherData>(dto);

        // Assert
        data.Should().NotBeNull();
        
        data.Location.Should().NotBeNull();
        data.Location.Name.Should().Be(dto!.Location!.Name);

        data.Current.Should().NotBeNull();
        data.Current.LastUpdated.Should().Be(Utilities.GetTimeFromDate(dto!.Current!.LastUpdated));
        data.Current.Temperature.Should().Be((int)Math.Round(dto!.Current!.Temperature, 0));
        data.Current.Condition.Should().NotBeNull();
        data.Current.Condition.Text.Should().Be(dto!.Current!.Condition!.Text);
        data.Current.Condition.Icon.Should().Be(dto!.Current!.Condition!.Icon);
        data.Current.FeelsLike.Should().Be(dto!.Current!.FeelsLike);
        data.Current.Humidity.Should().Be(dto!.Current!.Humidity);
        data.Current.Wind.Should().Be(Utilities.Kmh2Ms(dto!.Current!.Wind));
        data.Current.Visibility.Should().Be(dto!.Current!.Visibility);

        data.Forecast.Should().NotBeNull();
        data.Forecast.Forecastday.Should().NotBeNullOrEmpty();
        data.Forecast.Forecastday.Should().ContainSingle();
        data.Forecast.Forecastday[0].Date.Should().Be(dto!.Forecast!.Forecastday[0].Date);
        data.Forecast.Forecastday[0].Day.Should().NotBeNull();
        data.Forecast.Forecastday[0].Day.MaxTemperature.Should().Be(Math.Round(dto!.Forecast!.Forecastday[0].Day!.MaxTemperature, 0));
        data.Forecast.Forecastday[0].Day.MinTemperature.Should().Be(Math.Round(dto!.Forecast!.Forecastday[0].Day!.MinTemperature, 0));
        data.Forecast.Forecastday[0].Day.Condition.Should().NotBeNull();
        data.Forecast.Forecastday[0].Day.Condition.Text.Should().Be(dto!.Forecast!.Forecastday[0].Day!.Condition!.Text);
        data.Forecast.Forecastday[0].Day.Condition.Icon.Should().Be(dto!.Forecast!.Forecastday[0].Day!.Condition!.Icon);
    }

    #region Private Methods

    private MapperConfiguration CreateConfig()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<Application.Profiler>();
        }, new NullLoggerFactory());
    }

    #endregion Private Methods
}
