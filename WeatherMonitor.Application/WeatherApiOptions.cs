namespace WeatherMonitor.Application;

public class WeatherApiOptions
{
    public const string SectionName = "WeatherApi";

    public double Lat { get; set; }
    public double Lon { get; set; }
    public string ApiKey { get; set; } = string.Empty;
}
