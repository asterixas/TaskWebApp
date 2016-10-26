using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskWebApp.Startup))]
namespace TaskWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
