using ApolloDb.Infrastructure;
using NHibernate;

namespace ApolloDb.Updates
{
    public class UpdateToVs009
    {
        public static void Run()
        {
            Sl.Resolve<ExecuteSqlFile>().Run(ScriptPath.Get("008-add-field-notfallkontakt.sql"));
        }
    }
}