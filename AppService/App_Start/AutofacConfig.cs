namespace AppService
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.WebApi;
    using Data;
    using Data.Models;
    using Data.Services.UnitOfWork;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin.Security;


    public static class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register services
            RegisterServices(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver =
     new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.Register(x => new HomiesDbContext())
                .As<DbContext>()
                .InstancePerRequest();

            builder.RegisterType<HomiesDataSystem>()
                .As<IHomiesDataSystem>()
                .InstancePerRequest();

            builder.RegisterType<UserStore<ApplicationUser>>()
                .As<IUserStore<ApplicationUser>>()
                .InstancePerRequest();

            builder.RegisterType<ApplicationUserManager>()
                .AsSelf()
                .InstancePerRequest();

            builder.Register(x => HttpContext.Current.GetOwinContext().Authentication)
                .As<IAuthenticationManager>()
                .InstancePerRequest();
        }
    }
}