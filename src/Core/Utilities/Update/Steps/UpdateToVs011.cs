using ApolloDb.Infrastructure;

namespace ApolloDb.Updates
{
    public class UpdateToVs011
    {
        public static void Run()
        {
            Sl.Resolve<ExecuteSqlFile>().Run(ScriptPath.Get("011-add-multiple-fields.sql"));
        }
    }
}