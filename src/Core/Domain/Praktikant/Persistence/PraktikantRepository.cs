using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Seedworks.Lib.Persistence;

namespace ApolloDb
{
    public class PraktikantRepository : RepositoryDb<Praktikant>
    {
        public PraktikantRepository(ISession session) : base(session) { }
    }
}
