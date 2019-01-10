using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PelotitasService.Startup))]

namespace PelotitasService
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