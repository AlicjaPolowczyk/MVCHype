using HYPEDanceStudio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Domain.Interfaces
{
    public interface IAssignmentRepository
    {
        Task Create(Assignment assignment);
        Task<IEnumerable<Assignment>> GetAll();
        Task<Domain.Entities.Assignment> GetById(int id);
        Task Commit();
        Task Delete (Assignment assignment);
    }
}
