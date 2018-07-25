using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ATMvc.Startup))]
namespace ATMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
