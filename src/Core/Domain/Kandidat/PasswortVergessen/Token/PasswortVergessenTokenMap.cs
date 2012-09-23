using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace ApolloDb
{
    class PasswortVergessenTokenMap : ClassMap<PasswortVergessenToken>
    {
        public PasswortVergessenTokenMap()
        {
            Id(x => x.Id);
            Map(x => x.Token);
            Map(x => x.Email);
            Map(x => x.DateModified);
            Map(x => x.DateCreated);
        }
    }
}
