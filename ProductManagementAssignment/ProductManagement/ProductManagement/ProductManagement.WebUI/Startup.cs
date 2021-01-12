using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductManagement.WebUI.Startup))]
namespace ProductManagement.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
