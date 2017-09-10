using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LocaVideos.Startup))]
namespace LocaVideos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
