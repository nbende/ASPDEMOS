using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnglrApp.Startup))]
namespace AnglrApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
