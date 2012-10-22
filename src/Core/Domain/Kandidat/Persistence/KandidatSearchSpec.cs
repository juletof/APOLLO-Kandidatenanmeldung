using Seedworks.Lib.Persistence;

namespace ApolloDb
{
    public class KandidatSearchSpec : SearchSpecificationBase<KandidatFilter, KandidatOrderBy>
    {
    }

    public class KandidatFilter : ConditionContainer
    {
        public ConditionDisjunction<KandidatStatus> Stati;
        public ConditionInteger Uni;
        public ConditionTextSearch TextSearch;

        public KandidatFilter()
        {
            Stati = new ConditionDisjunction<KandidatStatus>(this, "Status");
            Uni = new ConditionInteger(this, "Hochschule");
            TextSearch = new ConditionTextSearch(this, "Familienname", "FamiliennameKY", "Vorname", "VornameKY",
                "Vatersname", "VatersnameKY", "EmailAdresse", "Mobilnummer", "NummerInlandspass", 
                "EmailAdresse", "Mobilnummer", "Kommentar", "KommentarApollo");
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