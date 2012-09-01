using System.Reflection;
using Autofac;
using NHibernate;
using Module = Autofac.Module;

namespace ApolloDb
{
    public class AutofacCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("ApolloDb.Frontend.Web"))
                   .AssignableTo<IRegisterAsInstancePerLifetime>();

            var assemblyFrontendWeb = Assembly.Load("ApolloDb.Core");
            builder.RegisterAssemblyTypes(assemblyFrontendWeb).AssignableTo<IRegisterAsInstancePerLifetime>();
            builder.RegisterAssemblyTypes(assemblyFrontendWeb).Where(a => a.Name.EndsWith("Repository"));

            builder.RegisterInstance(SessionFactory.CreateSessionFactory());
            builder.Register(context => new SessionManager(context.Resolve<ISessionFactory>().OpenSession())).InstancePerLifetimeScope();
            builder.Register(context => context.Resolve<SessionManager>().Session).ExternallyOwned();
        }
    }
}