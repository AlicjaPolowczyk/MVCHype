using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Application.Assignment.Commands.CreateAssignment
{
    public class CreateAssignmentValidator : AbstractValidator<CreateAssignmentCommand>
    {
        public CreateAssignmentValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull();
            RuleFor(c => c.Description).NotEmpty().NotNull();
            RuleFor(c => c.Status).NotEmpty().NotNull();
            RuleFor(c => c.Email).NotEmpty().NotNull();
        }
    }
}
