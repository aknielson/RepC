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
                var person = uow.People.GetAll().FirstOrDefault();
                var phone = person.Phones.FirstOrDefault();
                var address = person.Address;
                var wtf = phone.PhoneNumber;
                var phones = person.Phones.ToList();
               
               
                Console.WriteLine(person.LastName);
                Console.WriteLine();
            }
        }
    
    }
}
