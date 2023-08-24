using DemoLibrary.Models;
using MediatR;

namespace DemoLibrary.Queries;

// IRequest상속된 메소드를 호출하면 연결된 IRequestHandler를 찾아서 실행한다.
public record GetPersonByIdQuery(int Id) : IRequest<PersonModel>;

/// record를 사용하면 아래와 같은 코드를 줄일 수 있다.
//public class GetPersonByIdQueryClass : IRequest<PersonModel>
//{
//    public GetPersonByIdQueryClass(int id)
//    {
//        Id = id;
//    }

//    public int Id { get; set; }
//}

public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonModel>
{
    private readonly IMediator _mediator;

    public GetPersonByIdHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetPersonListQuery(), cancellationToken);
        var person = result.FirstOrDefault(x => x.Id == request.Id);

        return person!;
    }
}

