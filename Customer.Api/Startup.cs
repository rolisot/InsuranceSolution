using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Customer.Api.Startup))]

namespace Customer.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
