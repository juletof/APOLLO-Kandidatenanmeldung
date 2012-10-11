using ApolloDb.Infrastructure;

namespace ApolloDb.Updates
{
    public class UpdateToVs002
    {
        public static void Run()
        {
            ServiceLocator.Resolve<ExecuteSqlFile>().Run(
                ScriptPath.Get("002-setting-fields-adminUserPwd.sql"));
        }
    }
}