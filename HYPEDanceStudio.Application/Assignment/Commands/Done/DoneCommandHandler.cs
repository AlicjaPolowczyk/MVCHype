using HYPEDanceStudio.Application.ApplicationUser;
using HYPEDanceStudio.Application.Person.Commands.EditPerson;
using HYPEDanceStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Application.Assignment.Commands.Done
{
    public class DoneCommandHandler : IRequestHandler<DoneCommand>
    {

        private readonly IAssignmentRepository _assignmentrepository;
        private readonly IUserContext _userContext;

        public DoneCommandHandler(IAssignmentRepository assignmentrepository, IUserContext userContext)
        {
            _assignmentrepository = assignmentrepository;
            _userContext = userContext;

        }
        public async Task<Unit> Handle(DoneCommand request, CancellationToken cancellationToken)
        {
            var assignment = await _assignmentrepository.GetById(request.Id!);

            assignment.Status = "Done";

            await _assignmentrepository.Commit();
            return Unit.Value;
        }
    }
}
