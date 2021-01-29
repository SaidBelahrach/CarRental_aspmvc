using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(projet_ASP.Startup))]
namespace projet_ASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
