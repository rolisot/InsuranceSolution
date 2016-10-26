using Insurance.Domain.Services;
using Ninject.Modules;
using Quotations.Service.Services;

namespace QuotationMonitor
{
    public class QuotationModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IQuotationService>()
                .To<QuotationService>().InSingletonScope();
        }
    }
}
