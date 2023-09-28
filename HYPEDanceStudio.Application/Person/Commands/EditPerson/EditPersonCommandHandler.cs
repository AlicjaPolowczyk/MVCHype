using AutoMapper;
using HYPEDanceStudio.Application.ApplicationUser;
using HYPEDanceStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Application.Person.Commands.EditPerson
{
    public class EditPersonCommandHandler : IRequestHandler<EditPersonCommand>
    {
        private readonly IPersonRepository _repository;
        private readonly IUserContext _userContext;

        public EditPersonCommandHandler(IPersonRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;

        }
        public async Task<Unit> Handle(EditPersonCommand request, CancellationToken cancellationToken)
        {

            var person = await _repository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEdibable = user != null && (person.CreatedById == user.Id || user.isInRole("Owner") || user.isInRole("Moderator"));

            if (!isEdibable || user == null )
            {
                return Unit.Value;
            }

            person.Name=request.Name;
            person.LastName = request.LastName;
            person.Location = request.Location;
            person.ContactDetails.PhoneNumber = request.PhoneNumber;
            person.ContactDetails.Email=request.Email;
            person.EncodeName();

           await  _repository.Commit();
            return Unit.Value;
        }
    }
}
