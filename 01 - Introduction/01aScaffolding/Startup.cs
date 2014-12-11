using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_01aScaffolding.Startup))]
namespace _01aScaffolding
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
