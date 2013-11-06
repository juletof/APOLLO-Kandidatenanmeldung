using System.Collections.Generic;

namespace ApolloDb
{
    public class NamensBereiniger
    {
        public static void Run(IList<Kandidat> praktis)
        {
            foreach (var p in praktis)
            {
                p.Vorname = Sanitize(p.Vorname);
                p.VornameKY = Sanitize(p.VornameKY);
                p.Vatersname = Sanitize(p.Vatersname);
                p.VatersnameKY = Sanitize(p.VatersnameKY);
                p.Familienname = Sanitize(p.Familienname);
                p.FamiliennameKY = Sanitize(p.FamiliennameKY);

            }
        }

        public static string Sanitize(string stringSanitize)
        {
            if (stringSanitize == null)
                return "";

            stringSanitize = stringSanitize.ToLower();
            if (stringSanitize.Length > 0)
                stringSanitize = stringSanitize[0].ToString().ToUpper()[0]
                                 + stringSanitize.Substring(1);

            return stringSanitize;
        }
    }
}