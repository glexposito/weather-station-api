namespace WeatherStation.Api.Models;

public record WeatherReading(
    int Id,
    string Location,
    double TemperatureC,
    double HumidityPercent,
    DateTime Timestamp
);