using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TocaLivrosTeste.MVC.Startup))]
namespace TocaLivrosTeste.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
