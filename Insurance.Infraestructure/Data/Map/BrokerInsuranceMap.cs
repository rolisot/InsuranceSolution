using Insurance.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Insurance.Infraestructure.Data.Map
{
    public class BrokerInsuranceMap : EntityTypeConfiguration<BrokerInsurance>
    {
        public BrokerInsuranceMap()
        {
            ToTable("BrokerInsurances");

            HasKey(x => x.BrokerInsuranceId);

            Property(x => x.Login)
               .HasMaxLength(40)
               .IsRequired();

            Property(x => x.Password)
               .HasMaxLength(32)
               .IsFixedLength()
               .IsRequired();

            Property(x => x.Active)
               .IsRequired();

             HasRequired(x => x.Broker)
             .WithMany(x => x.BrokerInsurance)
             .Map(m => m.MapKey("BrokerId"));

            HasRequired(x => x.Insurance)
             .WithMany(x => x.BrokerInsurance)
             .Map(m => m.MapKey("InsuranceId"));
        }
    }
}
