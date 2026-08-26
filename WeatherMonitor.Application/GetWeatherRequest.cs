using MediatR;

namespace WeatherMonitor.Application;

public class GetWeatherRequest : IRequest<GetWeatherResponse>
{
    public GetWeatherRequest(double lat, double lon)
    {
        Lat = lat;
        Lon = lon;
    }

    public double Lat { get; set; }

    public double Lon { get; set; }
}
