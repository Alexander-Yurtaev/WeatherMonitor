using AutoMapper;
using MediatR;
using System.Globalization;
using System.Net.Http.Json;
using WeatherMonitor.Domain;

namespace WeatherMonitor.Application;

public class WeatherHandlers : IRequestHandler<GetWeatherRequest, GetWeatherResponse>
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMapper _mapper;

    public WeatherHandlers(IHttpClientFactory httpClientFactory, IMapper mapper)
    {
        _httpClientFactory = httpClientFactory;
        _mapper = mapper;
    }

    public async Task<GetWeatherResponse> Handle(GetWeatherRequest request, CancellationToken cancellationToken)
    {
        var lat = request.Lat.ToString(CultureInfo.InvariantCulture);
        var lon = request.Lon.ToString(CultureInfo.InvariantCulture);

        var response = new GetWeatherResponse();

        try
        {
            var client = _httpClientFactory.CreateClient("WeatherHandlersClient");
            var dto = await client.GetFromJsonAsync<WeatherDto>($"?key=fa8b3df74d4042b9aa7135114252304&q={lat},{lon}&days=3");
            response.Data = _mapper.Map<WeatherData>(dto);
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
        }
        return response;
    }
}
