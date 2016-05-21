using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SquaresAdmin.Startup))]
namespace SquaresAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
