using ApolloDb.Infrastructure;

namespace ApolloDb.Updates
{
    public class UpdateToVs006
    {
        public static void Run()
        {
            ServiceLocator.Resolve<ExecuteSqlFile>().Run(
                ScriptPath.Get("006-rename-praktikumsjahr-to-studienjahr.sql"));
        }
    }
}