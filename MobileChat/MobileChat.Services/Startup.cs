using System.Reflection;
using System.Web.Http;

using Microsoft.Owin;
using MobileChat.Data;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

using Exam.WebApi.Infrastructure;

[assembly: OwinStartup(typeof(MobileChat.Services.Startup))]

namespace MobileChat.Services
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseNinjectMiddleware(CreateKernel)
               .UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        public StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);

            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IMobileChatData>()
                  .To<MobileChatData>()
                  .WithConstructorArgument("context", c => new MobileChatDbContext());

            kernel.Bind<IUserIDProvider>().To<AspUserIDProvider>();
        }
    }
}
