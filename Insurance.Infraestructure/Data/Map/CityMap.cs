using Insurance.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Insurance.Infraestructure.Data.Map
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            ToTable("City");

            Property(x => x.CityId)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name)
                .HasMaxLength(38)
                .IsRequired();

            //Property(x => x.StateId)
            //    .IsRequired();

            Property(x => x.Capital)
                .IsRequired();

            //1:N
            HasRequired(x => x.State)
              .WithMany(x => x.Cities)
              .Map(m => m.MapKey("StateId"));
        }
    }
}
