using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Broker.Api.Startup))]

namespace Broker.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
