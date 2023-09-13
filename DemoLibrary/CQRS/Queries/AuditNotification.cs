using MediatR;

namespace DemoLibrary.CQRS.Queries;
public class AuditNotification : INotification
{
    public string Message { get; set; }
}
