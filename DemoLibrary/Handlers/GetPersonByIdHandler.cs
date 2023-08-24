using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;

namespace DemoLibrary.Handlers;
//public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonModel>
//{
//    private readonly IMediator _mediator;

//    public GetPersonByIdHandler(IMediator mediator)
//    {
//        _mediator = mediator;
//    }

//    public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
//    {
//        var result = await _mediator.Send(new GetPersonListQuery(), cancellationToken);
//        var person = result.FirstOrDefault(x => x.Id == request.Id);

//        return person!;
//    }
//}
