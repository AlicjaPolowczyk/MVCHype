using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Application.Person
{
    public class PersonDto
    {
        public string Name { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Location { get; set; } = default!;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public string? EncodedName { get; set; }

        public bool IsEditable { get; set; }


    }
}
