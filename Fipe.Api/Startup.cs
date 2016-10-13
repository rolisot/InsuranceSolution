using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Fipe.Api.Startup))]

namespace Fipe.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
