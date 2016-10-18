using Insurance.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Insurance.Infraestructure.Data.Map
{
    public class StateMap : EntityTypeConfiguration<State>
    {
        public StateMap()
        {
            ToTable("State");

            HasKey(x => x.StateId);

            Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();

            Property(x => x.Abbreviation)
                .HasMaxLength(2)
                .IsRequired();
        }
    }
}
