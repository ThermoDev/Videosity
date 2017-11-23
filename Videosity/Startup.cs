using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Videosity.Startup))]
namespace Videosity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
