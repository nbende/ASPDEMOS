using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelloAllWorlds.Startup))]
namespace HelloAllWorlds
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
