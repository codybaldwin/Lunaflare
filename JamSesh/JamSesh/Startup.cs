using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JamSesh.Startup))]
namespace JamSesh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
