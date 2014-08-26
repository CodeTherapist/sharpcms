using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using SharpCms.Core.Contracts.Data;
using SharpCms.Data.FileSystem;

namespace SharpCmsWeb
{
    public class IoCConfig
    {
        public static void RegisterIoC()
        {
            var currentAssembly = typeof(MvcApplication).Assembly;

            var builder = new ContainerBuilder();

            builder.RegisterControllers(currentAssembly);
            builder.RegisterModelBinders(currentAssembly);
            builder.RegisterModelBinderProvider();
            builder.RegisterFilterProvider();

            builder.RegisterModule(new AutofacWebTypesModule());

            builder.RegisterType(typeof(SitetreeProvider)).As(typeof(ISitetreeProvider));
            builder.RegisterType(typeof(PageProvider)).As(typeof(IPageProvider));

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}