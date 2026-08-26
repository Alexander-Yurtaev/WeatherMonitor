using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Net.Http.Json;
using WeatherMonitor.Application.Requests;
using WeatherMonitor.Application.Responses;
using WeatherMonitor.Domain.Data;
using WeatherMonitor.Domain.Dto;

namespace WeatherMonitor.Application.Handlers;

public class WeatherHandlers : IRequestHandler<GetWeatherRequest, GetWeatherResponse>
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMapper _mapper;
    private readonly IOptions<WeatherApiOptions> _weatherApiOptions;

    public WeatherHandlers(
        IHttpClientFactory httpClientFactory, 
        IMapper mapper,
        IOptions<WeatherApiOptions> weatherApiOptions)
    {
        _httpClientFactory = httpClientFactory;
        _mapper = mapper;
        _weatherApiOptions = weatherApiOptions;
    }

    public async Task<GetWeatherResponse> Handle(GetWeatherRequest request, CancellationToken cancellationToken)
    {
        var lat = request.Lat.ToString(CultureInfo.InvariantCulture);
        var lon = request.Lon.ToString(CultureInfo.InvariantCulture);
        var api_key = _weatherApiOptions.Value.ApiKey;

        var response = new GetWeatherResponse();

        try
        {
            var client = _httpClientFactory.CreateClient("WeatherHandlersClient");
            var dto = await client.GetFromJsonAsync<WeatherDto>($"?key={api_key}&q={lat},{lon}&days=3");
            response.Data = _mapper.Map<WeatherData>(dto);

            var lastUpdatedHour = Utilities.GetHourFromTime(response.Data.Current.LastUpdated);
            var currentDay = response.Data.Forecast.Forecastday[0].Hour;
            response.Data.Forecast.Forecastday[0].Hour = [.. currentDay.Where(c => Utilities.GetHourFromTime(c.Time) >= lastUpdatedHour)];
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
        }
        return response;
    }
}
