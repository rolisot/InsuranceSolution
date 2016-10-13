using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Signature.Api.Startup))]

namespace Signature.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
