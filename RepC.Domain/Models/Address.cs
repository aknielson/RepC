using System;
using System.Collections.Generic;

namespace RepC.Domain.Models
{
    public partial class Address
    {
       

        public int Id { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
       
    }
}
