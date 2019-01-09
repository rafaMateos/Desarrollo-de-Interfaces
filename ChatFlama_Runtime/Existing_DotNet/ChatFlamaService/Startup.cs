using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ChatFlamaService.Startup))]

namespace ChatFlamaService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}