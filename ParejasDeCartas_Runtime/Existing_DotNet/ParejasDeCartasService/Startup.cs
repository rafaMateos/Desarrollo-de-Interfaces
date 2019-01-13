using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ParejasDeCartasService.Startup))]

namespace ParejasDeCartasService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
            app.MapSignalR();
        }
    }
}