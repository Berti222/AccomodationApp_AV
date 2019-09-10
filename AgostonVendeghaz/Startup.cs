using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgostonVendeghaz.Startup))]
namespace AgostonVendeghaz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
