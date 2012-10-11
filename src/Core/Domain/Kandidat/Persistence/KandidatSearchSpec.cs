using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seedworks.Lib.Persistence;

namespace ApolloDb
{
    public class KandidatSearchSpec : SearchSpecificationBase<KandidatFilter, KandidatOrderBy>
    {
    }

    public class KandidatFilter : ConditionContainer
    {
        public ConditionDisjunction<KandidatStatus> Stati;

        public KandidatFilter()
        {
            Stati = new ConditionDisjunction<KandidatStatus>(this, "Status");
        }
    }

    public class KandidatOrderBy : OrderByCriteria
    {
        public OrderBy Created;
        public OrderBy Modified;

        public KandidatOrderBy()
        {
            Created = new OrderBy("DateCreated", this);
            Modified = new OrderBy("DateModified", this);
        }
    }
}