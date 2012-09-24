using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ApolloDb;
using Autofac;
using Autofac.Integration.Mvc;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using Gibraltar.Agent;

namespace Frontend.Web
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
            Log.StartSession();
            Log.MessageAlert += Log_MessageAlert;

            InitializeAutofac();
            AreaRegistration.RegisterAllAreas();

#if DEBUG
            NHibernateProfiler.Initialize();
#endif

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        void Log_MessageAlert(object sender, LogMessageAlertEventArgs e)
        {
            if (e.TopSeverity <= LogMessageSeverity.Error) //numeric values DROP for more severe enum values
            {
                e.SendSession = true;
                e.MinimumDelay = new TimeSpan(0, 5, 0); //5 minutes
            }
        }

        private static void InitializeAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new AutofacCoreModule());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}