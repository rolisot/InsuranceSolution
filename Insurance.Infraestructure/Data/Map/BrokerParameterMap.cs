using Insurance.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Insurance.Infraestructure.Data.Map
{
    public class BrokerParameterMap : EntityTypeConfiguration<BrokerParameter>
    {
        public BrokerParameterMap()
        {
            ToTable("BrokerParameter");

            HasKey(x => x.BrokerParameterId);

            Property(x => x.Commission)
                .HasPrecision(4,2)
                .IsRequired();

            HasRequired(x => x.Broker)
             .WithMany(x => x.BrokerParameter)
             .Map(m => m.MapKey("BrokerId"));
        }
    }
}
