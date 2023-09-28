using HYPEDanceStudio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task Create(Domain.Entities.Person person);
        Task <IEnumerable<Domain.Entities.Person>> GetAll();
        Task <Domain.Entities.Person> GetByEncodedName (string encodedName);
        Task Commit();
        Task Delete(Domain.Entities.Person person);
     
    }
}
