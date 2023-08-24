using DemoLibrary.DataAccess;
using DemoLibrary.Models;
using MediatR;

namespace DemoLibrary.Commands;


// IRequest상속된 메소드를 호출하면 연결된 IRequestHandler를 찾아서 실행한다.
public record InsertPersonCommand(string FirstName, string LastName) : IRequest<PersonModel>;

//public class InsertPersonCommand : IRequest<PersonModel>
//{
//    public string FirstName { get; set; }
//    public string LastName { get; set; }

//    public InsertPersonCommand(string firstName, string lastName)
//    {
//        FirstName = firstName;
//        LastName = lastName;
//    }
//}


public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, PersonModel>
{
    private readonly IDataAccess _data;

    public InsertPersonHandler(IDataAccess data)
    {
        _data = data;
    }

    public Task<PersonModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_data.InsertPerson(request.FirstName, request.LastName));
    }
}
