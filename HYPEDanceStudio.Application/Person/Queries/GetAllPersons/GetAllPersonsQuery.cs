using MediatR;

namespace HYPEDanceStudio.Application.Person.Queries.GetAllPersons
{
    public class GetAllPersonsQuery : IRequest<IEnumerable<PersonDto>>
    {
    }
}