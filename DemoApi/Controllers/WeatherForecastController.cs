using DemoLibrary.CQRS.Queries;
using DemoLibrary.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(
        IMediator mediator,
        ILogger<WeatherForecastController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<WeatherForecast> Get()
    {
        // https://www.youtube.com/watch?v=qIxNHf3wbLw
        var response = await _mediator.Send(new WeatherMessage());

        await _mediator.Publish(new AuditNotification { Message = "Weather forecast retrieved" });

        return response;
    }

    // 아래의 코드를 MediatR를 사용하여 처리하였음.

    //private static readonly string[] Summaries = new[]
    //{
    //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //};

    //private readonly ILogger<WeatherForecastController> _logger;

    //public WeatherForecastController(ILogger<WeatherForecastController> logger)
    //{
    //    _logger = logger;
    //}

    //[HttpGet(Name = "GetWeatherForecast")]
    //public IEnumerable<WeatherForecast> Get()
    //{
    //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //        {
    //            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //            TemperatureC = Random.Shared.Next(-20, 55),
    //            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //        })
    //        .ToArray();
    //}
}


