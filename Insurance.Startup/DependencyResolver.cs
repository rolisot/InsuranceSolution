using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Domain.Services;
using Insurance.Infraestructure.Data;
using Insurance.Infraestructure.Repositories;
using Microsoft.Practices.Unity;
using Security.Service.Services;
using User.Service.Services;

namespace Insurance.Startup
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<ISecurityRepository, SecurityRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISecurityService, SecurityService>(new HierarchicalLifetimeManager());
            container.RegisterType<User, User>(new HierarchicalLifetimeManager());

            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());
            container.RegisterType<User, User>(new HierarchicalLifetimeManager());

            container.RegisterType<ICustomerRepository, CustomerRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICustomerService, CustomerService>(new HierarchicalLifetimeManager());
            container.RegisterType<Customer, Customer>(new HierarchicalLifetimeManager());

            container.RegisterType<IStateRepository, StateRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IStateService, StateService>(new HierarchicalLifetimeManager());
            container.RegisterType<State, State>(new HierarchicalLifetimeManager());

            container.RegisterType<ICityRepository, CityRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICityService, CityService>(new HierarchicalLifetimeManager());
            container.RegisterType<City, City>(new HierarchicalLifetimeManager());
        }
    }
}
