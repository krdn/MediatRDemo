using DemoLibrary.DataAccess;
using DemoLibrary.Logger;
using DemoLibrary.Models;
using MediatR;

namespace DemoLibrary.CQRS.Queries;

// IRequest상속된 메소드를 호출하면 연결된 IRequestHandler를 찾아서 실행한다.
public record GetPersonListQuery() : IRequest<List<PersonModel>>;
