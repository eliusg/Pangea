using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PangeaProyecto.Startup))]
namespace PangeaProyecto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
