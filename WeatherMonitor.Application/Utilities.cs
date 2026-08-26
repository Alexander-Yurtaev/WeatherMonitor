namespace WeatherMonitor.Application;

public static class Utilities
{
    public static double Kmh2Ms(double kmh)
    {
        return Math.Round(kmh * 1000 / 60 / 60, 1);
    }

    public static int GetHourFromTime(string time)
    {
        return int.Parse(time.Substring(0, 2));
    }
}
