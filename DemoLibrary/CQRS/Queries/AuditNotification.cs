using MediatR;

namespace DemoLibrary.CQRS.Queries;
public record AuditNotification : INotification
{
    public string Message { get; set; }
}
