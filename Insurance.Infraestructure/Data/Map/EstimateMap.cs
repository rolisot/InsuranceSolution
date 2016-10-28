using Insurance.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Insurance.Infraestructure.Data.Map
{
    public class EstimateMap : EntityTypeConfiguration<Estimate>
    {
        public EstimateMap()
        {
            ToTable("Estimate");

            HasKey(x => x.EstimateId);

            Property(x => x.Price)
                .HasPrecision(9, 2)
                .IsRequired();

            Property(x => x.Status)
                .IsRequired();  

            HasRequired(x => x.QuotationBroker)
             .WithMany(x => x.Estimates)
             .Map(m => m.MapKey("QuotationBrokerId"));
        }
    }
}
