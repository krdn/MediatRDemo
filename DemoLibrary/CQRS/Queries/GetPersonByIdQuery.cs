using DemoLibrary.Models;
using MediatR;

namespace DemoLibrary.CQRS.Queries;

// IRequest상속된 메소드를 호출하면 연결된 IRequestHandler를 찾아서 실행한다.
public record GetPersonByIdQuery(int Id) : IRequest<PersonModel>;

// record를 사용하면 아래와 같은 코드를 줄일 수 있다.
//public class GetPersonByIdQueryClass : IRequest<PersonModel>
//{
//    public GetPersonByIdQueryClass(int id)
//    {
//        Id = id;
//    }

//    public int Id { get; set; }
//}
