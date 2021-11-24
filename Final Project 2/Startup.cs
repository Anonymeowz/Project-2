using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Final_Project_2.Startup))]
namespace Final_Project_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
