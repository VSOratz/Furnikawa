using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PickingByVoice.Startup))]
namespace PickingByVoice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
