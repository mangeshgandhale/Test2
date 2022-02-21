using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC3Layer.Startup))]
namespace MVC3Layer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
