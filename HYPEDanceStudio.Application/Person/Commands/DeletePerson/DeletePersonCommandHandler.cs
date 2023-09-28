using HYPEDanceStudio.Application.ApplicationUser;
using HYPEDanceStudio.Application.Person.Commands.EditPerson;
using HYPEDanceStudio.Domain.Entities;
using HYPEDanceStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Application.Person.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {

        private readonly IPersonRepository _repository;
        private readonly IUserContext _userContext;

        public DeletePersonCommandHandler(IPersonRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;

        }
        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _repository.GetByEncodedName(request.EncodedName!);
            var user = _userContext.GetCurrentUser();
            var isEdibable = user != null && (person.CreatedById == user.Id || user.isInRole("Owner") || user.isInRole("Moderator"));

            if (!isEdibable || user == null)
            {
                return Unit.Value;
            }

            await _repository.Delete(person);
            return Unit.Value;
        }
    }
}
