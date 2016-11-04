using Insurance.Domain.Repositories;
using Insurance.Domain.Services;
using Insurance.Infraestructure.Repositories;
using Ninject.Modules;

namespace CalculateIntegrationMonitor
{
    public class CalculateIntegrationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICalculateIntegrationService>()
               .To<CalculateIntegrationService>().InSingletonScope();

            Bind<IQuotationRepository>()
                .To<QuotationRepository>().InSingletonScope();

            Bind<ICalculateIntegrationRepository>()
                .To<CalculateIntegrationRepository>().InSingletonScope();

            Bind<IEstimateRepository>()
               .To<EstimateRepository>().InSingletonScope();

            //Bind<IBrokerInsuranceRepository>()
            //   .To<BrokerInsuranceRepository>().InSingletonScope();
        }
    }
}
