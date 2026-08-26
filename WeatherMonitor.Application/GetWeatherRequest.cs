using MediatR;

namespace WeatherMonitor.Application;

public class GetWeatherRequest : IRequest<GetWeatherResponse>
{
    public GetWeatherRequest(float lat, float lon)
    {
        Lat = lat;
        Lon = lon;
    }

    public float Lat { get; set; }

    public float Lon { get; set; }
}
