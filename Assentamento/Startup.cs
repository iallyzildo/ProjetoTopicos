using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assentamento.Startup))]
namespace Assentamento
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
