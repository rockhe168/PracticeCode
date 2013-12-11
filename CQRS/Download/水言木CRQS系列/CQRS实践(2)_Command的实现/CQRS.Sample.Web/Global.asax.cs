using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Autofac;
using NHibernate;

using CQRS.Commanding;
using CQRS.Data;
using CQRS.Data.Nh;
using CQRS.Sample.Data;
using System.Reflection;

namespace CQRS.Sample.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            ObjectContainer.Initialize(x =>
            {
                x.Register(c => SessionManager.OpenSession()).As<ISession>();

                x.RegisterType<NhUnitOfWork>().Named<IUnitOfWork>("UnitOfWorkImpl");
                x.Register(c =>
                {
                    if (UnitOfWorkContext.CurrentUnitOfWork != null)
                    {
                        return UnitOfWorkContext.CurrentUnitOfWork;
                    }
                    return c.ResolveNamed<IUnitOfWork>("UnitOfWorkImpl");
                }).As<IUnitOfWork>();

                x.RegisterGeneric(typeof(NhRepository<>)).As(typeof(IRepository<>));

                x.RegisterType<DefaultCommandBus>().As<ICommandBus>().SingleInstance();

                var asm = Assembly.Load("CQRS.Sample");

                x.RegisterAssemblyTypes(asm).Where(it => !it.IsInterface && !it.IsAbstract).AsClosedTypesOf(typeof(ICommandExecutor<>));
            });
        }
    }
}