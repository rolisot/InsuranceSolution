using Insurance.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Insurance.Infraestructure.Data.Map
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            ToTable("City");

            HasKey(x => x.CityId);

            Property(x => x.Name)
                .HasMaxLength(40)
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
