using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Niall_Firmstep.Startup))]
namespace Niall_Firmstep
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
