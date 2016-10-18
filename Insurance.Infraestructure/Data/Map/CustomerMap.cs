using Insurance.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Insurance.Infraestructure.Data.Map
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customer");

            HasKey(x => x.CustomerId);

            //Property(x => x.Name)
            //    .HasMaxLength(60)
            //    .IsRequired();

            Property(x => x.Name)
                .HasMaxLength(120)
                .IsRequired();

            Property(x => x.Cpf)
               .HasMaxLength(11)
               .IsRequired();

            Property(x => x.Phone)
              .HasMaxLength(10);

            Property(x => x.Phone)
             .HasMaxLength(11)
             .IsRequired();

            //1:N
            //HasRequired(x => x.City)
            //  .WithMany(x => x.Cities)
            //  .Map(m => m.MapKey("CityId"));
        }
    }
}
