using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Application.Person.Commands.CreatePerson
{
    public class CreatePersonCommand : PersonDto, IRequest
    {
    }
}
