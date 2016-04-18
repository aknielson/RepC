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
                Console.WriteLine(person.LastName);
                Console.WriteLine();
            }
        }
    
    }
}
