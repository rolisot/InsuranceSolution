using Insurance.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Insurance.Infraestructure.Data.Map
{
    public class CustomerAddressMap : EntityTypeConfiguration<CustomerAddress>
    {
        public CustomerAddressMap()
        {
            ToTable("CustomerAddress");

            HasKey(x => x.CustomerId);

            Property(x => x.Address)
                .HasMaxLength(240)
                .IsRequired();

            Property(x => x.Cep)
               .HasMaxLength(8)
               .IsRequired();

            Property(x => x.Neighborhood)
               .HasMaxLength(240)
               .IsOptional();

            Property(x => x.Latitude)
                .HasPrecision(12, 9)
                .IsOptional();

            Property(x => x.Longitude)
                .HasPrecision(12, 9)
                .IsOptional();

            HasRequired(x => x.City)
              .WithMany(x => x.CustomerAddress)
              .Map(m => m.MapKey("CityId"));

            HasRequired(x => x.Customer)
                .WithRequiredDependent(x => x.Address);
        }
    }
}
