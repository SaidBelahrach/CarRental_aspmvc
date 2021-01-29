using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetASP.Startup))]
namespace ProjetASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
