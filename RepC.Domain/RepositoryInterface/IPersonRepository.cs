using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepC.Domain.Models;

namespace RepC.Domain.RepositoryInterface
{
    public interface IPersonRepository : IRepository<Person>
    {
        void RemoveHydrated(Person entity);
    }
}
