using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Application.Assignment.Queries.GetAssignments
{
    public class GetAssignmentsQuery : IRequest<IEnumerable<AssignmentDto>>
    {
    }
}
