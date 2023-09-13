using DemoLibrary.CQRS.Queries;
using MediatR;

namespace DemoLibrary.CQRS.Handlers;
public class AuditNotificationHandler : INotificationHandler<AuditNotification>
{
    public Task Handle(AuditNotification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Audit notification: {notification.Message}");
        return Task.CompletedTask;
    }
}
