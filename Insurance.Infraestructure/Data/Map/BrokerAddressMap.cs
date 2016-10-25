using Insurance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Infraestructure.Data.Map
{
    public class BrokerAddressMap : EntityTypeConfiguration<BrokerAddress>
    {
        public BrokerAddressMap()
        {
            ToTable("BrokerAddress");

            HasKey(x => x.BrokerId);

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
              .WithMany(x => x.BrokerAddress)
              .Map(m => m.MapKey("CityId"));

            HasRequired(x => x.Broker)
                .WithRequiredDependent(x => x.Address);
        }
    }
}
