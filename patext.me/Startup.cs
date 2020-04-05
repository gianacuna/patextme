using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(patext.me.Startup))]
namespace patext.me
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
