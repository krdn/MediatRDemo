using DemoLibrary.DataAccess;
using DemoLibrary.Models;
using MediatR;

namespace DemoLibrary.Queries;

// IRequest상속된 메소드를 호출하면 연결된 IRequestHandler를 찾아서 실행한다.
public record GetPersonListQuery() : IRequest<List<PersonModel>>;

public class GetPersonListHandler : IRequestHandler<GetPersonListQuery, List<PersonModel>>
{
    private readonly IDataAccess _data;

    public GetPersonListHandler(IDataAccess data)
    {
        _data = data;
    }

    public Task<List<PersonModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_data.GetPeople());
    }
}


