using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Estimate.Api.Startup))]

namespace Estimate.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
