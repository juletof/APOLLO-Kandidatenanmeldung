using System;
using NHibernate;
using NHibernate.Criterion;

namespace ApolloDb
{
    public class UniStatistikLaden : IRegisterAsInstancePerLifetime
    {
        private readonly ISession _session;

        public UniStatistikLaden(ISession session){
            _session = session;
        }

        public UniStatistikLadenResult Run()
        {
            var dbResults = _session.QueryOver<Kandidat>()
                .Select(
                    Projections.Group<Kandidat>(k => k.Hochschule),
                    Projections.Count<Kandidat>(k => k.Hochschule)
                ).List<object[]>();

            var result = new UniStatistikLadenResult();

            foreach (var dbResult in dbResults)
            {
                result.Add(
                    Convert.ToInt32(dbResult[0]), 
                    Convert.ToInt32(dbResult[1])
                );
            }

            return result;
        }
    }
}
