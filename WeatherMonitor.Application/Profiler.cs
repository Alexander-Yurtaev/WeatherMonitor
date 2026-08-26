using AutoMapper;
using System.Text.Json.Serialization;
using WeatherMonitor.Domain;

namespace WeatherMonitor.Application;

public class Profiler : Profile
{
    public Profiler()
    {
        CreateMap<WeatherDto, WeatherData>()
            .ForMember(dest => dest.Location, opt => opt.MapFrom(l => l.Location))
            .ForMember(dest => dest.Current, opt => opt.MapFrom(l => l.Current))
            .ForMember(dest => dest.Forecast, opt => opt.MapFrom(l => l.Forecast));

        CreateMap<LocationDto, Location>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(l => l.Name));

        CreateMap<CurrentDto, Current>()
            .ForMember(dest => dest.LastUpdated, opt => opt.MapFrom(c => c.LastUpdated.Substring(c.LastUpdated.Length - 5)))
            .ForMember(dest => dest.Temperature, opt => opt.MapFrom(c => Math.Round(c.Temperature, 0)))
            .ForMember(dest => dest.Condition, opt => opt.NullSubstitute(new ConditionDto()))
            .ForMember(dest => dest.FeelsLike, opt => opt.MapFrom(c => Math.Round(c.FeelsLike, 0)))
            .ForMember(dest => dest.Humidity, opt => opt.MapFrom(c => c.Humidity))
            .ForMember(dest => dest.Wind, opt => opt.MapFrom(c => Utilities.Kmh2Ms(c.Wind)))
            .ForMember(dest => dest.Visibility, opt => opt.MapFrom(c => c.Visibility));

        CreateMap<ConditionDto, Condition>()
            .ForMember(dest => dest.Text, opt => opt.MapFrom(c => c.Text))
            .ForMember(dest => dest.Icon, opt => opt.MapFrom(c => c.Icon));

        CreateMap<ForecastDto, Forecast>()
            .ForMember(dest => dest.Forecastday, opt => opt.MapFrom(c => c.Forecastday));

        CreateMap<ForecastdayDto, Forecastday>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(f => f.Date))
            .ForMember(dest => dest.Day, opt => opt.NullSubstitute(new DayDto()))
            .ForMember(dest => dest.Hour, opt => opt.MapFrom(f => f.Hour));

        CreateMap<DayDto, Day>()
            .ForMember(dest => dest.MaxTemperature, opt => opt.MapFrom(d => d.MaxTemperature))
            .ForMember(dest => dest.MinTemperature, opt => opt.MapFrom(d => d.MinTemperature))
            .ForMember(dest => dest.Condition, opt => opt.NullSubstitute(new ConditionDto()));

        CreateMap<HourDto, Hour>()
            .ForMember(dest => dest.Time, opt => opt.MapFrom(h => h.Time.Substring(h.Time.Length - 5)))
            .ForMember(dest => dest.Temperature, opt => opt.MapFrom(h => Math.Round(h.Temperature, 0)))
            .ForMember(dest => dest.Condition, opt => opt.NullSubstitute(new ConditionDto()));
    }
}