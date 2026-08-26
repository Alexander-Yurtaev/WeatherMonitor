namespace WeatherMonitor.Application;

public static class Utilities
{
    public static float Kmh2Ms(float kmh)
    {
        return kmh * 1000 / 60;
    }
}
