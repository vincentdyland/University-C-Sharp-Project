using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JustBlog.Ui.Startup))]
namespace JustBlog.Ui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
