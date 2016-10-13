using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Quotation.Api.Startup))]

namespace Quotation.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
