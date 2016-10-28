using Insurance.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Insurance.Infraestructure.Data.Map
{
    public class CalculateIntegrationMap : EntityTypeConfiguration<CalculateIntegration>
    {
        public CalculateIntegrationMap()
        {
            ToTable("CalculateIntegration");

            HasKey(x => x.CalculateIntegrationId);

            Property(x => x.SendDate)
               .IsOptional();

            Property(x => x.SendText)
              .IsRequired();

            Property(x => x.ReceiveDate)
               .IsOptional();

            Property(x => x.ReceiveText)
              .IsOptional();

            Property(x => x.Status)
                .IsRequired();

            HasRequired(x => x.Quotation)
              .WithMany(x => x.CalculateIntegration)
              .Map(m => m.MapKey("QuotationId"));

            HasRequired(x => x.Broker)
              .WithMany(x => x.CalculateIntegration)
              .Map(m => m.MapKey("BrokerId"));

        }
    }
}
