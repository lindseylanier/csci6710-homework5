using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(csci6710_homework5.Startup))]
namespace csci6710_homework5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
