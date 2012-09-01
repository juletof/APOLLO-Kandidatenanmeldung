using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace ApolloDb
{
    public class PraktikantMap : ClassMap<Praktikant>
    {
        public PraktikantMap()
        {
            Id(x => x.Id);
            Id(x => x.Name);
            Map(x => x.DateModified);
            Map(x => x.DateCreated);
        }
    }
}
