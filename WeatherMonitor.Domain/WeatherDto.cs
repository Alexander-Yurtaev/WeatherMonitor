using System.Text.Json.Serialization;

namespace WeatherMonitor.Domain;

public class WeatherDto
{
    public LocationDto? Location { get; set; }
    public CurrentDto? Current { get; set; }
    public ForecastDto? Forecast { get; set; }
}

public class LocationDto
{
    public string Name { get; set; } = string.Empty;
}

public class CurrentDto
{
    [JsonPropertyName("last_updated")]
    public string LastUpdated { get; set; } = "Сейчас";

    [JsonPropertyName("temp_c")]
    public float Temperature { get; set; }

    [JsonPropertyName("condition")]
    public ConditionDto? Condition { get; set; }

    [JsonPropertyName("feelslike_c")]
    public float FeelsLike { get; set; }

    public int Humidity { get; set; }

    [JsonPropertyName("wind_kph")]
    public float Wind { get; set; }

    [JsonPropertyName("vis_km")]
    public float Visibility { get; set; }
}

public class ConditionDto
{
    public string Text { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
}

public class ForecastDto
{
    public ForecastdayDto[] Forecastday { get; set; } = [];
}

public class ForecastdayDto
{
    public string Date { get; set; } = string.Empty;
    public DayDto? Day { get; set; }
    public HourDto[] Hour { get; set; } = [];
}

public class DayDto
{
    [JsonPropertyName("maxtemp_c")]
    public float MaxTemperature { get; set; }

    [JsonPropertyName("mintemp_c")]
    public float MinTemperature { get; set; }

    public ConditionDto? Condition { get; set; }
}

public class HourDto
{
    public string Time { get; set; } = string.Empty;

    [JsonPropertyName("temp_c")]
    public float Temperature { get; set; }

    public ConditionDto? Condition { get; set; }
}