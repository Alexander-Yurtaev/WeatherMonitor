using System.Text.Json.Serialization;

namespace WeatherMonitor.Domain;

public class WeatherData
{
    public Location? Location { get; set; }
    public Current? Current { get; set; }
    public Forecast? Forecast { get; set; }
}

public class Location
{
    public string Name { get; set; } = string.Empty;
}

public class Current
{
    [JsonPropertyName("last_updated")]
    public string LastUpdated { get; set; } = string.Empty;

    [JsonPropertyName("temp_c")]
    public float Temperature { get; set; }

    [JsonPropertyName("condition")]
    public Condition? Condition { get; set; }

    [JsonPropertyName("feelslike_c")]
    public float FeelsLike { get; set; }

    public int humidity { get; set; }

    [JsonPropertyName("wind_kph")]
    public float Wind { get; set; }

    [JsonPropertyName("vis_km")]
    public float Visibility { get; set; }
}

public class Condition
{
    public string Text { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
}

public class Forecast
{
    public Forecastday[] Forecastday { get; set; } = [];
}

public class Forecastday
{
    public string Date { get; set; } = string.Empty;
    public Day? Day { get; set; }
    public Hour[] Hour { get; set; } = [];
}

public class Day
{
    [JsonPropertyName("maxtemp_c")]
    public float MaxTemperature { get; set; }

    [JsonPropertyName("mintemp_c")]
    public float MinTemperature { get; set; }

    public Condition? Condition { get; set; }
}

public class Hour
{
    public string Time { get; set; } = string.Empty;

    [JsonPropertyName("temp_c")]
    public float Temperature { get; set; }

    public Condition? Condition { get; set; }
}