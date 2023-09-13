using DemoLibrary.CQRS.Commands;
using DemoLibrary.DataAccess;
using DemoLibrary.Models;
using MediatR;

namespace DemoLibrary.CQRS.Handlers;

public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, PersonModel>
{
    private readonly IDataAccess _data;
    private readonly IPublisher _publisher;


    public InsertPersonHandler(IDataAccess data, IPublisher publisher)
    {
        _data = data;
        _publisher = publisher;
    }

    public async Task<PersonModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
    {
        await _publisher.Publish(new InsertPersonCommand(request.FirstName, request.LastName), cancellationToken);

        return await Task.FromResult(_data.InsertPerson(request.FirstName, request.LastName));
    }
}
