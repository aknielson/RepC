using System;
using System.Collections.Generic;

namespace RepC.Domain.Models
{
    public partial class Phone
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneTypeId { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public virtual PhoneType PhoneType { get; set; }
    }
}
