using Insurance.Domain.Repositories;
using Insurance.Domain.Services;
using Insurance.Infraestructure.Repositories;
using Ninject.Modules;
using Quotations.Service.Services;

namespace QuotationMonitor
{
    public class QuotationModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IQuotationBrokersService>()
                .To<QuotationBrokersService>().InSingletonScope();

            Bind<IQuotationRepository>()
                .To<QuotationRepository>().InSingletonScope();

            Bind<IBrokerRepository>()
                .To<BrokerRepository>().InSingletonScope();

            Bind<IBrokerInsuranceRepository>()
               .To<BrokerInsuranceRepository>().InSingletonScope();
        }
    }
}
