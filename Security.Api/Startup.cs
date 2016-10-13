using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Security.Api.Startup))]

namespace Security.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
