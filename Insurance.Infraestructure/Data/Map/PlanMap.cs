using Insurance.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Insurance.Infraestructure.Data.Map
{
    public class PlanMap : EntityTypeConfiguration<Plan> 
    {
        public PlanMap()
        {
            ToTable("Plan");

            HasKey(x => x.PlanId);

            Property(x => x.Description)
                .HasMaxLength(20)
                .IsRequired();

            Property(x => x.Days)
                .IsRequired();

            Property(x => x.Price)
                .IsRequired();

            Property(x => x.Active)
               .IsRequired();
        }
    }
}
