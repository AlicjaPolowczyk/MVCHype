using HYPEDanceStudio.Application.Person.Queries.GetPersonByEncodedName;
using HYPEDanceStudio.Application.Person;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HYPEDanceStudio.Domain.Interfaces;
using HYPEDanceStudio.Domain.Entities;

namespace HYPEDanceStudio.Application.Assignment.Queries.GetAssignmentById
{
    internal class GetAssignmentByIdQueryHandler : IRequestHandler<GetAssignmentByIdQuery, AssignmentDto>
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IMapper _mapper;

        public GetAssignmentByIdQueryHandler(IAssignmentRepository assignmentRepository, IMapper mapper)
        {
            _assignmentRepository = assignmentRepository;
            _mapper = mapper;
        }

        public async Task<AssignmentDto> Handle(GetAssignmentByIdQuery request, CancellationToken cancellationToken)
        {
            var assignment = await _assignmentRepository.GetById(request.Id);
            var dto = _mapper.Map<AssignmentDto>(assignment);
            return dto;
        }
    }
}
