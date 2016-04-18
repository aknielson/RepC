using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RepC.Domain;
using RepC.Domain.Models;

namespace RepC.EFData.Models.Mapping
{
    public class PhoneMap : EntityTypeConfiguration<Phone>
    {
        public PhoneMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Phone");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.PhoneTypeId).HasColumnName("PhoneTypeId");
            this.Property(t => t.PersonId).HasColumnName("PersonId");

            // Relationships
            this.HasRequired(t => t.Person)
                .WithMany(t => t.Phones)
                .HasForeignKey(d => d.PersonId);
            this.HasRequired(t => t.PhoneType)
                .WithMany(t => t.Phones)
                .HasForeignKey(d => d.PhoneTypeId);

        }
    }
}
