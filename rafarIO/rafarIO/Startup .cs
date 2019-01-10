
using Microsoft.Owin;
using Owin;



[assembly: OwinStartup(typeof(rafarIO.Startup))]

namespace rafarIO
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