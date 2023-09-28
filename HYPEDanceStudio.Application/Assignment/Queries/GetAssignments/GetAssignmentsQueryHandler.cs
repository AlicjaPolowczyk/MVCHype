using AutoMapper;
using HYPEDanceStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Application.Assignment.Queries.GetAssignments
{
    public class GetAssignmentsQueryHandler : IRequestHandler<GetAssignmentsQuery, IEnumerable<AssignmentDto>>
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IMapper _mapper;

        public GetAssignmentsQueryHandler(IAssignmentRepository assignmentRepository, IMapper mapper)
        {
            _assignmentRepository = assignmentRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AssignmentDto>> Handle(GetAssignmentsQuery request, CancellationToken cancellationToken)
        {
            var results = await _assignmentRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<AssignmentDto>>(results);
            return dtos;
        }
    }
}
