using System;
using NHibernate;
using NHibernate.Criterion;

namespace ApolloDb
{
    public class IsEmailAddressInUse : IRegisterAsInstancePerLifetime
    {
        private readonly ISession _session;

        public IsEmailAddressInUse(ISession session){
            _session = session;
        }

        public bool Yes(string emailAddress)
        {
            var resultCount = _session.QueryOver<Kandidat>()
                                      .Select(Projections.RowCount())
                                      .Where(k => k.EmailAdresse == emailAddress)
                                      .SingleOrDefault<int>();

            if (resultCount == 0)
                return false;

            if (resultCount > 1)
                throw new Exception("unexpected count");

            return true;
        }
    }
}
