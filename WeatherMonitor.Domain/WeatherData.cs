namespace WeatherMonitor.Domain;

public class WeatherData
{
    public Location Location { get; set; }
    public Current Current { get; set; }
    public Forecast Forecast { get; set; }
}

public class Location
{
    public string Name { get; set; } = string.Empty;
}

public class Current
{
    public string LastUpdated { get; set; } = string.Empty;
    public int Temperature { get; set; }
    public Condition Condition { get; set; }
    public double FeelsLike { get; set; }
    public int Humidity { get; set; }
    public double Wind { get; set; }
    public double Visibility { get; set; }
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
    public Day Day { get; set; }
    public Hour[] Hour { get; set; } = [];
}

public class Day
{
    public double MaxTemperature { get; set; }
    public double MinTemperature { get; set; }
    public Condition Condition { get; set; }
}

public class Hour
{
    public string Time { get; set; } = string.Empty;
    public int Temperature { get; set; }
    public Condition Condition { get; set; }
}