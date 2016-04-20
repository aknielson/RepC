using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepC.EFData;

namespace RepC.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var uow = new UnitOfWork())
            {
                var person = uow.People.GetHydrated(1);

                var foof = uow.People.Get(25);
                foof = uow.People.Hydrate(foof);

                //whats difference between remove Hydrated and remove?
                uow.People.RemoveHydrated(foof);

                uow.People.Remove(uow.People.Get(19));
                uow.Complete();

               
               // var person = uow.People.GetHydrated(1);
                Console.WriteLine(person.GetType());
                var phone = person.Phones.FirstOrDefault();
                Console.WriteLine(phone.GetType());
                var address = person.Address;
                Console.WriteLine(address.GetType());
                var wtf = phone.PhoneNumber;
                var phones = person.Phones.ToList();
               
               
                Console.WriteLine(person.LastName);
                Console.WriteLine();
            }
        }
    
    }
}
