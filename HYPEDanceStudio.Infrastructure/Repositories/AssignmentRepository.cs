using HYPEDanceStudio.Application.Assignment.Commands.DeleteAssignment;
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
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly PersonDbContext _dbContext;

        public AssignmentRepository(PersonDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        public async Task Create(Assignment assignment)
        {
            _dbContext.Assignemnts.Add(assignment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Assignment>> GetAll()
        => await _dbContext.Assignemnts.ToListAsync();

        public async Task<Assignment> GetById(int id)
       => await _dbContext.Assignemnts.FirstAsync(c => c.Id == id);

        public Task Commit()
        => _dbContext.SaveChangesAsync();

        public async Task Delete(Assignment assignment)
        {
            _dbContext.Assignemnts.Remove(assignment);
            await _dbContext.SaveChangesAsync();

        }
        
    }
}
