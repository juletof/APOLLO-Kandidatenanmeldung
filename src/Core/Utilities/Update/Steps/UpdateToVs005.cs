using ApolloDb.Infrastructure;

namespace ApolloDb.Updates
{
    public class UpdateToVs005
    {
        public static void Run()
        {
            ServiceLocator.Resolve<ExecuteSqlFile>().Run(
                ScriptPath.Get("005-removeKurs-from-tbl-Kandidat.sql"));
        }
    }
}