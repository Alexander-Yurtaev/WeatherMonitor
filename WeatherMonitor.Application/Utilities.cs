namespace WeatherMonitor.Application;

public static class Utilities
{
    public static double Kmh2Ms(double kmh)
    {
        return Math.Round(kmh * 1000 / 60 / 60, 1);
    }

    public static int GetHourFromTime(string value)
    {
        if (!DateTime.TryParse(value, out var time)) return 0;
        return time.Hour;
    }

    public static string GetTimeFromDate(string value)
    {
        if (!DateTime.TryParse(value, out var datetime)) return "--";
        return datetime.ToString("HH:mm");
    }
}
