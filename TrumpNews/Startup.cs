using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrumpNews.Startup))]
namespace TrumpNews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
