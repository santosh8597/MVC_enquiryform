using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnquiryForm.Startup))]
namespace EnquiryForm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
