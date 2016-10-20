using Insurance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Infraestructure.Data.Map
{
    public class BrokerPlanMap : EntityTypeConfiguration<BrokerPlan>
    {
        public BrokerPlanMap()
        {
            ToTable("BrokerPlan");

            HasKey(x => new {x.BrokerId,x.PlanId});

            Property(x => x.BuyDate)
               .IsRequired();

            Property(x => x.ExpireDate)
                .IsOptional();

            HasRequired(x => x.Broker)
            .WithMany(x => x.BrokerPlan)
            .HasForeignKey(x => x.BrokerId);
            //.Map(m => m.MapKey("BrokerId"));

            HasRequired(x => x.Plan)
             .WithMany(x => x.BrokerPlan)
             .HasForeignKey(x => x.PlanId);
             //.Map(m => m.MapKey("PlanId"));
        }
    }
}
