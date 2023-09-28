using AutoMapper;
using HYPEDanceStudio.Application.ApplicationUser;
using HYPEDanceStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Application.Person.Commands.CreatePerson
{
    internal class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand>
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        private readonly IUserContext _userContext;

        public CreatePersonCommandHandler(IMapper mapper, IPersonRepository personRepository , IUserContext userContext) 
        {
            _mapper = mapper;
            _personRepository=personRepository;
            _userContext=userContext;
        }
        public async Task<Unit> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            if(currentUser == null || !currentUser.isInRole("Owner")) 
            {
                return Unit.Value;
            }
            var person = _mapper.Map<Domain.Entities.Person>(request);
            person.EncodeName();
            person.CreatedById = currentUser.Id;
            await _personRepository.Create(person);

            return Unit.Value;
        }
    }
}
