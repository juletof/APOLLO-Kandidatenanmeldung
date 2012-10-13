using NHibernate;
using Seedworks.Lib.Persistence;

namespace ApolloDb
{
    public class StatuswechselRepository :  RepositoryDb<Statuswechsel>
    {
        public StatuswechselRepository(ISession session) : base(session) { } 
    }
}
