using Insurance.Domain.Models;

namespace Insurance.Infraestructure.Data.Map
{
    public class StateMap : EntityTypeConfiguration<State>
    {
        public StateMap()
        {
            ToTable("State");

            Property(x => x.StateId)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Abbreviation)
                .HasMaxLength(2)
                .IsRequired();
        }
    }
}
