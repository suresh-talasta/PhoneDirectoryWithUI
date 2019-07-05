using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomerPhoneNumber_2.Startup))]
namespace CustomerPhoneNumber_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
