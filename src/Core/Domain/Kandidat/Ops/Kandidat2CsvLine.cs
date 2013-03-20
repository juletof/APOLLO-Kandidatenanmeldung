using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ApolloDb.Domain.Kandidat.Lists;

namespace ApolloDb
{
    public class Kandidat2CsvLine
    {

        public static string RunFirstLine()
        {
            return "Geschlecht" + ";" +
                   "Familienname" + ";" +
                   "FamiliennamKY" + ";" +
                   "Vorname" + ";" +
                   "VornameKY" + ";" +
                   "VatersnameKY" + ";" +
                   "EmailAdresse" + ";" +
                   "Mobilnummer" + ";" +
                   "Geburtsdatum" + ";" +
                   "Alter" + ";" +
                   "NummerInlandspass" + ";" +
                   "Uni" + ";" +
                   "Fakultät" + ";" +
                   "Studienfach" + ";" +
                   "Spezialisierung" + ";" +
                   "Studienjahr" + ";" +
                   "VerkürzterStudiengang" + ";" +
                   "AngestrebterAbschluss" + ";" +
                   "Deutschkentnisse" + ";" +
                   "DeutschkentnisseDurchSchule" + ";" +
                   "DeutschkentnisseDurchUni" + ";" +
                   "DeutschkentnisseDurchSonstige" + ";" +
                   "FruehererAufenthalt" + ";" +
                   "FruehererAufenthaltProgramm" + ";" +
                   "Kommentar" + ";" +
                   "KommentarApollo" + ";" +
                   "Status";
        }

        public static string Run(Kandidat k)
        {
            return k.Geschlecht + ";" +
                   k.Familienname + ";" +
                   k.FamiliennameKY + ";" +
                   k.Vorname + ";" +
                   k.VornameKY + ";" +
                   k.VatersnameKY + ";" +
                   k.EmailAdresse + ";" +
                   k.Mobilnummer + ";" +
                   GetGeburtsdatum(k.Geburtsdatum) + ";" +
                   k.GetAlter() + ";" +
                   k.NummerInlandspass + ";" +
                   new Universitaeten().GermanLabel(k.Hochschule, "") + ";" +
                   k.Fakultät + ";" +
                   new Studienfaecher().GermanLabel(k.Studienfach, "") + ";" +
                   k.Spezialisierung + ";" +
                   new Studienjahr().GermanLabel(k.PraktikumsJahr, "") + ";" +
                   k.VerkürzterStudiengang + ";" +
                   new Abschluesse().GermanLabel(k.AngestrebterAbschluss, "") + ";" +
                   k.Deutschkentnisse + ";" +
                   k.DeutschkentnisseDurchSchule + ";" +
                   k.DeutschkentnisseDurchUni + ";" +
                   k.DeutschkentnisseDurchSonstige + ";" +
                   k.FruehererAufenthalt + ";" +
                   k.FruehererAufenthaltProgramm + ";" +
                   k.Kommentar + ";" +
                   k.KommentarApollo + ";" +
                   k.Status;
        }

        private static string GetGeburtsdatum(DateTime? geburtsdatum)
        {
            if (geburtsdatum == null)
                return "";

            return ((DateTime)geburtsdatum).ToString("MM.dd.yyy");
        }
    }


}