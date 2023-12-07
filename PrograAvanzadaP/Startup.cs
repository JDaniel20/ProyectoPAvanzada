using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrograAvanzadaP.Startup))]
namespace PrograAvanzadaP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
