using System.Collections.Generic;
using NHibernate;
using Seedworks.Lib.Persistence;

namespace ApolloDb
{
    public class KandidatRepository : RepositoryDb<Kandidat>
    {
        public KandidatRepository(ISession session) : base(session) { }

        public Kandidat GetByEmail(string emailAdresse)
        {
            return _session.QueryOver<Kandidat>()
                           .Where(k => k.EmailAdresse == emailAdresse)
                           .SingleOrDefault<Kandidat>();
        }

        public void Update(IList<Kandidat> kandis)
        {
            foreach (var kandidat in kandis)
                Update(kandidat);
        }
    }
}
