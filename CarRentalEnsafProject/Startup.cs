using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarRentalEnsafProject.Startup))]
namespace CarRentalEnsafProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
