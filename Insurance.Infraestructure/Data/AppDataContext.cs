using Insurance.Domain.Models;
using Insurance.Infraestructure.Data.Map;
using System.Data.Entity;

namespace Insurance.Infraestructure.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext() : base("AppConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Broker> Brokers { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<BrokerInsurance> BrokerInsurances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new InsuranceCompanyMap());
            modelBuilder.Configurations.Add(new PlanMap());
            modelBuilder.Configurations.Add(new BrokerMap());
            modelBuilder.Configurations.Add(new BrokerInsuranceMap());
            modelBuilder.Configurations.Add(new BrokerPlanMap());
            modelBuilder.Configurations.Add(new BrokerParameterMap());
            modelBuilder.Configurations.Add(new QuotationMap());
            modelBuilder.Configurations.Add(new QuotationBrokerMap());
            modelBuilder.Configurations.Add(new BrokerAddressMap());
        }
    }
}
