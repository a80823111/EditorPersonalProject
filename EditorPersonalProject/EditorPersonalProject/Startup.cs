using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EditorPersonalProject.Startup))]
namespace EditorPersonalProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
