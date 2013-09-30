using ApolloDb.Infrastructure;
using NHibernate;

namespace ApolloDb.Updates
{
    public class UpdateToVs007
    {
        public static void Run()
        {
            Sl.Resolve<ExecuteSqlFile>().Run(ScriptPath.Get("007-add-field-praktikumsjahr.sql"));
            Sl.Resolve<ISession>().CreateSQLQuery("UPDAte Kandidat SET PraktikumsJahr = '2013'").ExecuteUpdate();
        }
    }
}