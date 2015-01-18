using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_05fAntiForgery.Startup))]
namespace _05fAntiForgery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
