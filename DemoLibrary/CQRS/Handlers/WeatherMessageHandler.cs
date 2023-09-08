using DemoLibrary.CQRS.Queries;
using DemoLibrary.Models;
using MediatR;

namespace DemoLibrary.CQRS.Handlers;

public class WeatherMessageHandler : IRequestHandler<WeatherMessage, WeatherForecast>
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing",
        "Bracing",
        "Chilly",
        "Cool",
        "Mild",
        "Warm",
        "Balmy",
        "Hot",
        "Sweltering",
        "Scorching"
    };

    public Task<WeatherForecast> Handle(WeatherMessage request, CancellationToken cancellationToken)
    {
        var rng = new Random();
        var weatherForecast = new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)]
        };
        return Task.FromResult(weatherForecast);
    }
}