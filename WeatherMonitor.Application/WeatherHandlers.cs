using MediatR;
using System.Globalization;
using System.Net.Http.Json;
using WeatherMonitor.Domain;

namespace WeatherMonitor.Application;

public class WeatherHandlers : IRequestHandler<GetWeatherRequest, GetWeatherResponse>
{
    private readonly IHttpClientFactory _httpClientFactory;

    public WeatherHandlers(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<GetWeatherResponse> Handle(GetWeatherRequest request, CancellationToken cancellationToken)
    {
        var lat = request.Lat.ToString(CultureInfo.InvariantCulture);
        var lon = request.Lon.ToString(CultureInfo.InvariantCulture);

        var response = new GetWeatherResponse();

        try
        {
            var client = _httpClientFactory.CreateClient("WeatherHandlersClient");
            var data = await client.GetFromJsonAsync<WeatherData>($"?key=fa8b3df74d4042b9aa7135114252304&q={lat},{lon}&days=3");
            response.Data = data;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
        }
        return response;
    }
}
