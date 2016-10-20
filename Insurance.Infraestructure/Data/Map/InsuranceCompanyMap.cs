using Insurance.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace Insurance.Infraestructure.Data.Map
{
    public class InsuranceCompanyMap : EntityTypeConfiguration<InsuranceCompany>
    {
        public InsuranceCompanyMap()
        {
            ToTable("InsuranceCompany");

            HasKey(x => x.InsuranceId);

            Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();

            Property(x => x.Active)
                .IsRequired();
        }
    }
}
