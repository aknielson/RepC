using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepC.Domain.Models;
using RepC.Domain.RepositoryInterface;
using RepC.EFData.Models;

namespace RepC.EFData
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AddressBookAlphaContext _context;

        public UnitOfWork(AddressBookAlphaContext context)
        {
            _context = context;
            _context.Configuration.ProxyCreationEnabled = false;
            //People = new Repository<Person>(_context);
            People = new PersonRepository(_context);
           
            Addresses = new Repository<Address>(_context);
            Phones = new Repository<Phone>(_context);
            PhoneTypes = new Repository<PhoneType>(_context);

        }

        public UnitOfWork() : this(new AddressBookAlphaContext())
        {
        }
      

        public IHydrateRepository<Person> People { get; }
        public IRepository<Address> Addresses { get; }
        public IRepository<Phone> Phones { get; }
        public IRepository<PhoneType> PhoneTypes { get; }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
