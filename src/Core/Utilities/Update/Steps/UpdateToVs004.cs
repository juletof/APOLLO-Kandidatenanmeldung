using ApolloDb.Infrastructure;

namespace ApolloDb.Updates
{
    public class UpdateToVs004
    {
        public static void Run()
        {
            ServiceLocator.Resolve<ExecuteSqlFile>().Run(
                ScriptPath.Get("004-fieldApolloKommentar.sql"));
        }
    }
}