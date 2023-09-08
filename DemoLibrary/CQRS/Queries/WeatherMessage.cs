using DemoLibrary.Models;
using MediatR;

namespace DemoLibrary.CQRS.Queries;
public class WeatherMessage  : IRequest<WeatherForecast>
{
}
