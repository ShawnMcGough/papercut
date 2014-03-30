using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestTarget.Startup))]
namespace TestTarget
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
