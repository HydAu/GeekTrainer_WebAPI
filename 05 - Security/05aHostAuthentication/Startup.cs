using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_05aHostAuthentication.Startup))]
namespace _05aHostAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
