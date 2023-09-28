using AutoMapper;
using HYPEDanceStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Application.Person.Queries.GetAllPersons
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, IEnumerable<PersonDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;

        public GetAllPersonsQueryHandler(IMapper mapper, IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<PersonDto>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            var persons = await _personRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<PersonDto>>(persons);

            return dtos;
        }
    }
}
