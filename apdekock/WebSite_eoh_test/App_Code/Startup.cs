using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSite_eoh_test.Startup))]
namespace WebSite_eoh_test
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
