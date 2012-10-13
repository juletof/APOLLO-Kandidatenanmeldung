using ApolloDb.Infrastructure;

namespace ApolloDb.Updates
{
    public class UpdateToVs003
    {
        public static void Run()
        {
            ServiceLocator.Resolve<ExecuteSqlFile>().Run(
                ScriptPath.Get("003-statusWechsel.sql"));

            ServiceLocator.Resolve<StatuswechselInitialisieren>().Run();
        }
    }
}