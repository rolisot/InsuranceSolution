using Insurance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Infraestructure.Data.Map
{
    public class QuotationBrokerMap : EntityTypeConfiguration<QuotationBroker>
    {
        public QuotationBrokerMap()
        {
            ToTable("QuotationBroker");

            HasKey(x => x.QuotationBrokerId);

            HasRequired(x => x.Quotation)
            .WithMany(x => x.QuotationBroker)
            .Map(m => m.MapKey("QuotationId"));

            HasRequired(x => x.BrokerInsurance)
             .WithMany(x => x.QuotationBroker)
             .Map(m => m.MapKey("BrokerInsuranceId"));
        }
    }
}
