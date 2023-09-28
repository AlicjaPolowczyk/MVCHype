using FluentValidation;
using HYPEDanceStudio.Application.Person.Commands.CreatePerson;
using HYPEDanceStudio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Application.Person.Commands.EditPerson
{
    public class EditPersonCommandValidator : AbstractValidator<EditPersonCommand>
    {
        public EditPersonCommandValidator(IPersonRepository repository)
        {

            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);


            RuleFor(c => c.LastName)
               .NotEmpty()
               .MinimumLength(2)
               .MaximumLength(30);

            RuleFor(c => c.Location)
               .NotEmpty()
               .MinimumLength(2)
               .MaximumLength(20);

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(2)
                .MaximumLength(12);
        }
    }
}


