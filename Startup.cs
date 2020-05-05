using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InvoiceGen_ASPNET.Startup))]
namespace InvoiceGen_ASPNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
