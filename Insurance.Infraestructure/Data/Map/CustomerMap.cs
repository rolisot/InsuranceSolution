using Insurance.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Insurance.Infraestructure.Data.Map
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customer");

            HasKey(x => x.CustomerId);

            Property(x => x.Name)
                .HasMaxLength(120)
                .IsRequired();

            Property(x => x.Cpf)
               .HasMaxLength(11)
               .IsRequired();

            Property(x => x.Phone)
              .HasMaxLength(10);

            Property(x => x.BirthDate)
                .IsRequired();

            HasRequired(x => x.User)
             .WithMany(x => x.Customers)
             .Map(m => m.MapKey("UserId"));
        }
    }
}
