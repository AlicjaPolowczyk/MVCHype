using AutoMapper;
using HYPEDanceStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Application.Person.Queries.GetPersonByEncodedName
{
    public class GetPersonByEncodedNameQueryHandler : IRequestHandler<GetPersonByEncodedNameQuery, PersonDto>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public GetPersonByEncodedNameQueryHandler( IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<PersonDto> Handle(GetPersonByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetByEncodedName(request.EncodedName);
            var dto = _mapper.Map<PersonDto>(person);
            return dto;
        }
    }
}
