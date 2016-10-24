using Insurance.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Insurance.Infraestructure.Data.Map
{
    public class QuotationMap : EntityTypeConfiguration<Quotation>
    {
        public QuotationMap()
        {
            ToTable("Quotation");

            HasKey(x => x.QuotationId);

            Property(x => x.RegisterDate)
               .IsRequired();

            Property(x => x.Status)
                .IsRequired();

            //1:N
            HasOptional(x => x.City)
              .WithMany(x => x.Quotations)
              .Map(m => m.MapKey("CityId"));

            //1:N
            HasOptional(x => x.Customer)
              .WithMany(x => x.Quotations)
              .Map(m => m.MapKey("CustomerId"));
        }
    }
}
