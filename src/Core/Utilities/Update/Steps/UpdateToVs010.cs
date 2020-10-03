using ApolloDb.Infrastructure;

namespace ApolloDb.Updates
{
    public class UpdateToVs010
    {
        public static void Run()
        {
            Sl.Resolve<ExecuteSqlFile>().Run(ScriptPath.Get("010-add-field-nummer-reisepass.sql"));
        }
    }
}