using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Location { get; set; } = default!;
        public PersonContactDetails ContactDetails { get; set; } = default!;
        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }
        public string EncodedName { get; private set; } = default!;
        public void EncodeName() => EncodedName = Name.ToLower() + LastName.ToLower();

    }
}
