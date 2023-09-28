using HYPEDanceStudio.Application.ApplicationUser;
using HYPEDanceStudio.Application.Person.Commands.DeletePerson;
using HYPEDanceStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Application.Assignment.Commands.DeleteAssignment
{
    public class DeleteAssignmentCommandHandler : IRequestHandler<DeleteAssignmentCommand>
    {
        private readonly IAssignmentRepository _repository;
        private readonly IUserContext _userContext;

        public DeleteAssignmentCommandHandler(IAssignmentRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;

        }
        public async Task<Unit> Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
        {
            var user = _userContext.GetCurrentUser();
            var isEdibable = user != null && ( user.isInRole("Owner") || user.isInRole("Moderator"));

            if (!isEdibable || user == null)
            {
                return Unit.Value;
            }

            var assignment = await _repository.GetById(request.Id!);
            await _repository.Delete(assignment);
            return Unit.Value;
        }
    }
}
