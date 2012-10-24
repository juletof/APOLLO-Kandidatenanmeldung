using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApolloDb
{
    public class Kandidat2CsvLine
    {
        public static string Run(Kandidat k)
        {
            return k.Familienname + "," + k.FamiliennameKY + "," + k.Vorname + "," + k.VornameKY + "," + k.VatersnameKY + "," +
                   k.EmailAdresse + "," + k.Mobilnummer + "," + GetGeburtsdatum(k.Geburtsdatum) + "," + k.NummerInlandspass;
        }

        private static string GetGeburtsdatum(DateTime? geburtsdatum)
        {
            if (geburtsdatum == null)
                return "";

            return ((DateTime)geburtsdatum).ToString("MM.dd.yyy");
        }
    }
}
