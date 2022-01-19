using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stores.UI.Startup))]
namespace Stores.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
