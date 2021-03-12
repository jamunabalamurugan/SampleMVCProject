using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoredProcedureEg.Startup))]
namespace StoredProcedureEg
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
