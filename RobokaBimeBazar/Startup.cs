using Microsoft.Owin;
using Owin;
using RobokaBimeBazar;

[assembly: OwinStartup(typeof(Startup))]

namespace RobokaBimeBazar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
