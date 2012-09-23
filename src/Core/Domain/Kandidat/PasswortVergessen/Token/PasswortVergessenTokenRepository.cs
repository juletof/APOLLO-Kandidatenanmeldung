using NHibernate;
using Seedworks.Lib.Persistence;

namespace ApolloDb
{
    public class PasswortVergessenTokenRepository : RepositoryDb<PasswortVergessenToken>
    {
        public PasswortVergessenTokenRepository(ISession session) : base(session) { }
    }

}
