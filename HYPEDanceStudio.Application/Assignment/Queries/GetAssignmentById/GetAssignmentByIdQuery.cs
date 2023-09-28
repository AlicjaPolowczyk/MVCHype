using HYPEDanceStudio.Application.Person;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Application.Assignment.Queries.GetAssignmentById
{
    public class GetAssignmentByIdQuery : IRequest<AssignmentDto>
    {
        public int Id { get; set; }

        public GetAssignmentByIdQuery( int id)
        {
            Id = id;
        }
    }
}



