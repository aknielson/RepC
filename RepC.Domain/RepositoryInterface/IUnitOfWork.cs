using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepC.Domain.Models;

namespace RepC.Domain.RepositoryInterface
{
    public interface IUnitOfWork : IDisposable
    {

        //Must Add Repository for each Model
        // IPersonRepository People { get; }
        IRepository<Person> People { get; }
        IRepository<Address> Addresses { get; }
        IRepository<Phone> Phones { get; }
        IRepository<PhoneType> PhoneTypes { get; }

        int Complete();
    }
}
