using System;
using System.Collections.Generic;
using RepC.Domain.RepositoryInterface;

namespace RepC.Domain.Models
{
    public partial class Person 
    {
        public Person()
        {
            this.Phones = new List<Phone>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<int> AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
