using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoLibreria.Startup))]
namespace ProyectoLibreria
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
