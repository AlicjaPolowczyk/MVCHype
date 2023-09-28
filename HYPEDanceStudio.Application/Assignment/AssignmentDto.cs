using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Application.Assignment
{
    public class AssignmentDto
    {
        public int Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;

        public string Status { get; set; } = "not done";
        public string Email { get; set; } = default!;
    }
}
