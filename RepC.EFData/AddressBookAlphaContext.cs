using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using RepC.Domain.Models;
using RepC.EFData.Config;
using RepC.EFData.Models.Mapping;

namespace RepC.EFData.Models
{
    [DbConfigurationType(typeof(SqlDefaultDbConfiguration))]
    public partial class AddressBookAlphaContext : DbContext
    {
        static AddressBookAlphaContext()
        {
            Database.SetInitializer<AddressBookAlphaContext>(null);
        }

        public AddressBookAlphaContext()
            : base("Name=AddressBookAlphaContext")
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new PhoneMap());
            modelBuilder.Configurations.Add(new PhoneTypeMap());
        }
    }
}
