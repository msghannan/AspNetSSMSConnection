using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetSSMSConnection.Startup))]
namespace AspNetSSMSConnection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
