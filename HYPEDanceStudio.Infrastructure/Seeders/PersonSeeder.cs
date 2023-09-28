using HYPEDanceStudio.Domain.Entities;
using HYPEDanceStudio.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Infrastructure.Seeders
{
    public class PersonSeeder
    {
        private readonly PersonDbContext _dbContext;

        public PersonSeeder( PersonDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if( await  _dbContext.Database.CanConnectAsync() ) 
            {
                if( !_dbContext.Persons.Any())
                {
                    var instructor = new Person()
                    {
                        Name = "Alicja",
                        LastName = "Polowczyk",
                        Location = "Wojkowice",
                        ContactDetails = new PersonContactDetails()
                        {
                            PhoneNumber = "517451212",
                            Email = "alicjapolowczyk1990@gmail.com"
                        }
                    };
                    instructor.EncodeName();
                    _dbContext.Persons.Add(instructor);
                    await _dbContext.SaveChangesAsync();
                }

            }
        }
    }
}
