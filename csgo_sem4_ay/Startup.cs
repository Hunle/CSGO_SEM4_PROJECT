using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(csgo_sem4_ay.Startup))]
namespace csgo_sem4_ay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
