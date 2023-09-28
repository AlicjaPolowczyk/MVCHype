using HYPEDanceStudio.Domain.Entities;
using HYPEDanceStudio.Domain.Interfaces;
using HYPEDanceStudio.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Infrastructure.Repositories
{
    internal class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _dbContext;

        public PersonRepository(PersonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit()
        => _dbContext.SaveChangesAsync();

        public async Task Create(Domain.Entities.Person person)
        {
            _dbContext.Persons.Add(person);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Domain.Entities.Person person)
        {
            _dbContext.Persons.Remove(person);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> GetAll()
        => await _dbContext.Persons.ToListAsync();

        public async Task<Person> GetByEncodedName(string encodedName)
        => await _dbContext.Persons.FirstAsync(c => c.EncodedName == encodedName);
    }
}
