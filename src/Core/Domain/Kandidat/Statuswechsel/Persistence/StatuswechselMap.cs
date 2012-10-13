using FluentNHibernate.Mapping;

namespace ApolloDb
{
    public class StatuswechselMap : ClassMap<Statuswechsel>
    {
        public StatuswechselMap()
        {
            Id(x => x.Id);

            Map(x => x.KandidatId);
            Map(x => x.Status);
            Map(x => x.Zeitpunkt);

            Map(x => x.DateModified);
            Map(x => x.DateCreated);
        }
    }
}
