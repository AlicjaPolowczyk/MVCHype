using HYPEDanceStudio.Application.ApplicationUser;
using HYPEDanceStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Application.Assignment.Commands.CreateAssignment
{
    public class CreateAssignmentCommandHandler : IRequestHandler<CreateAssignmentCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IPersonRepository _personRepository;
        private readonly IAssignmentRepository _assignmentRepository;

        public CreateAssignmentCommandHandler(IUserContext userContext, IPersonRepository personRepository,
            IAssignmentRepository assignmentRepository)
        {
            _userContext = userContext;
            _personRepository = personRepository;
            _assignmentRepository = assignmentRepository;
        }
        public async Task<Unit> Handle(CreateAssignmentCommand request, CancellationToken cancellationToken)
        {
            //var person = await _personRepository.GetByEncodedName(request.PersonEncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEdibable = user != null && (user.isInRole("Owner") || user.isInRole("Moderator"));

            if (!isEdibable)
            {
                return Unit.Value;
            }

            var assignment = new Domain.Entities.Assignment()
            {
                Name = request.Name,
                Description = request.Description,
                Email = request.Email,
            };

            await _assignmentRepository.Create(assignment);

            return Unit.Value;
        }
    }
}