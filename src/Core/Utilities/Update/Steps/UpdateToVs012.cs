using ApolloDb.Infrastructure;

namespace ApolloDb.Updates
{
    public class UpdateToVs012
    {
        public static void Run()
        {
            Sl.Resolve<ExecuteSqlFile>().Run(ScriptPath.Get("012-add-multiple-fields.sql"));
        }
    }
}