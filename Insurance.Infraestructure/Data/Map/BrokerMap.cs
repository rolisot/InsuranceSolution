using Insurance.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Insurance.Infraestructure.Data.Map
{
    public class BrokerMap : EntityTypeConfiguration<Broker>
    {
        public BrokerMap()
        {
            ToTable("Broker");

            HasKey(x => x.BrokerId);

            Property(x => x.Name)
               .HasMaxLength(40)
               .IsRequired();

            Property(x => x.Cnpj)
                .HasMaxLength(14)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_BROKER_CNPJ", 1) { IsUnique = true }))
                .IsRequired();

            Property(x => x.Active)
                .IsRequired();

        }
    }
}
