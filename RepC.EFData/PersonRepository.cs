using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using RepC.Domain.Models;
using RepC.Domain.RepositoryInterface;

namespace RepC.EFData
{
    public class PersonRepository : Repository<Person>, IHydrateRepository<Person>
    {
        public PersonRepository(DbContext context) : base(context)
        {
        }

        public Person Hydrate(Person entity)
        {
            //may be quicker to just go get entity again with includes???
            entity.Address = Context.Set<Address>().AsNoTracking().SingleOrDefault(x => x.Id == entity.AddressId);
            entity.Phones =
                Context.Set<Phone>()
                    .Include(x => x.PhoneType)
                    .AsNoTracking()
                    .Where(x => x.PersonId == entity.Id)
                    .ToList();

            return entity;
        }

        public Person GetHydrated(int id)
        {
            var p1 = Context.Set<Person>().Include(x => x.Address).Include(x => x.Phones).FirstOrDefault(t => t.Id.Equals(id));

            return p1;
        }

        public Person SingleHydrated(Expression<Func<Person, bool>> predicate)
        {
            var p1 = Context.Set<Person>().Include(x => x.Address).Include(x => x.Phones).AsNoTracking().SingleOrDefault(predicate);
            return p1;
        }

        public void AddHydrated(Person entity)
        {
            throw new NotImplementedException();
        }
        

        public new void Remove(Person entity)  //new keywork hides base class repository
        {
            DbSet<Person> dbPerson = Context.Set<Person>();
            var personToRemove = dbPerson.Find(entity.Id);

            var phones = Context.Set<Phone>().Where(x => x.PersonId == entity.Id);
            Context.Set<Phone>().RemoveRange(phones);

            var address = Context.Set<Address>().Where(x => x.Id == entity.AddressId.Value);
            Context.Set<Address>().RemoveRange(address);

            dbPerson.Remove(personToRemove);

        }
    }
}
