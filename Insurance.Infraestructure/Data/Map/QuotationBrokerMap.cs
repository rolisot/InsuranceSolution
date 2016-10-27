using Insurance.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Insurance.Infraestructure.Data.Map
{
    public class QuotationBrokerMap : EntityTypeConfiguration<QuotationBroker>
    {
        public QuotationBrokerMap()
        {
            ToTable("QuotationBroker");

            HasKey(x => x.QuotationBrokerId);

            Property(x => x.QuotationBrokerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Quotation)
            .WithMany(x => x.QuotationBroker)
            .Map(m => m.MapKey("QuotationId"));

            HasRequired(x => x.BrokerInsurance)
             .WithMany(x => x.QuotationBroker)
             .Map(m => m.MapKey("BrokerInsuranceId"));
        }
    }
}
