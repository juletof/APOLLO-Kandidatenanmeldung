namespace ApolloDb.Domain.Kandidat.Lists
{
    public class Studienjahr : ListBase
    {
        public Studienjahr()
        {
            Add(1, "3 курс", "3. Studienjahr");
            Add(2, "4 курс", "4. Studienjahr");
            Add(3, "другое (аспиранты, магистры, после техникума)", "sonstige (Aspiranten, Magister, nach Technikum)");
        }
    }
}
