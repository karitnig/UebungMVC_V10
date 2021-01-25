using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UebungMVC_V10.Startup))]
namespace UebungMVC_V10
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
