using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OCDSApi.Startup))]
namespace OCDSApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
