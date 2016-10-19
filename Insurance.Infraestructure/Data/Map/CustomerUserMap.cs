using Insurance.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Insurance.Infraestructure.Data.Map
{
    public class CustomerUserMap : EntityTypeConfiguration<CustomerUser>
    {
        public CustomerUserMap()
        {
            ToTable("CustomerUser");

            HasKey(x => x.UserId)
                .Property(x => x.UserId).HasColumnName("CustomerId");

            Property(x => x.Email)
                .HasMaxLength(160)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_CUSTOMERUSER_EMAIL", 1) { IsUnique = true }))
                .IsRequired();

            Property(x => x.Password)
                .HasMaxLength(32)
                .IsFixedLength()
                .IsRequired();

            Property(x => x.Active)
                .IsRequired();

            Property(x => x.LastAccessDate)
               .IsRequired();

            Property(x => x.RegisterDate)
               .IsRequired();
        }
    }
}
