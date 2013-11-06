using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ApolloDb
{
    public class Kandidat2CsvLine
    {

        public static string RunFirstLine()
        {
            return "ID" + ";" +
                   "Status" + ";" +
                   "Kommentar Kandidat" + ";" +
                   "Kommentar Apollo" + ";" +
                   "Anrede" + ";" +
                   "Familienname" + ";" +
                   "Vorname" + ";" +
                   "FamiliennamKY" + ";" +
                   "VornameKY" + ";" +
                   "VatersnameKY" + ";" +
                   "EmailAdresse" + ";" +
                   "Mobilnummer" + ";" +
                   "Geburtsdatum" + ";" +
                   "Alter" + ";" +
                   "Uni" + ";" +
                   "Fakultät" + ";" +
                   "Studienfach" + ";" +
                   "Spezialisierung" + ";" +
                   "Studienjahr" + ";" +
                   "VerkürzterStudiengang" + ";" +
                   "AngestrebterAbschluss" + ";" +
                   "Nr. Inlandspass" + ";" +
                   "Deutschkentnisse" + ";" +
                   "DeutschkentnisseDurchSchule" + ";" +
                   "DeutschkentnisseDurchUni" + ";" +
                   "DeutschkentnisseDurchSonstige" + ";" +
                   "FruehererAufenthalt" + ";" +
                   "FruehererAufenthaltProgramm";

        }

        public static string Run(Kandidat k)
        {
            return Sanitize(k.Id) + ";" +
                   Sanitize(k.Status.ToString()) + ";" +
                   Sanitize(k.Kommentar) + ";" +
                   Sanitize(k.KommentarApollo) + ";" +
                   Sanitize(new AnredeWerte().GermanLabel(k.Geschlecht, "")) + ";" +
                   Sanitize(k.Familienname) + ";" +
                   Sanitize(k.Vorname) + ";" +
                   Sanitize(k.FamiliennameKY) + ";" +
                   Sanitize(k.VornameKY) + ";" +
                   Sanitize(k.VatersnameKY) + ";" +
                   Sanitize(k.EmailAdresse) + ";" +
                   Sanitize(k.Mobilnummer) + ";" +
                   Sanitize(GetGeburtsdatum(k.Geburtsdatum)) + ";" +
                   Sanitize(k.GetAlter()) + ";" +
                   Sanitize(new Universitaeten().GermanLabel(k.Hochschule, "")) + ";" +
                   Sanitize(k.Fakultät) + ";" +
                   Sanitize(new Studienfaecher().GermanLabel(k.Studienfach, "")) + ";" +
                   Sanitize(k.Spezialisierung) + ";" +
                   Sanitize(new Studienjahr().GermanLabel(k.Studienjahr, "")) + ";" +
                   Sanitize(k.VerkürzterStudiengang) + ";" +
                   Sanitize(new Abschluesse().GermanLabel(k.AngestrebterAbschluss, "")) + ";" +
                   Sanitize(k.NummerInlandspass) + ";" +
                   Sanitize(k.Deutschkentnisse) + ";" +
                   Sanitize(k.DeutschkentnisseDurchSchule) + ";" +
                   Sanitize(k.DeutschkentnisseDurchUni) + ";" +
                   Sanitize(k.DeutschkentnisseDurchSonstige) + ";" +
                   Sanitize(k.FruehererAufenthalt) + ";" +
                   Sanitize(k.FruehererAufenthaltProgramm);
                   

        }

        private static string GetGeburtsdatum(DateTime? geburtsdatum)
        {
            if (geburtsdatum == null)
                return "";

            return ((DateTime)geburtsdatum).ToString("dd.MM.yyy");
        }

        private static string Sanitize(bool fieldValue)
        {
            if (fieldValue)
                return "ja";

            return "";
        }

        private static string Sanitize(int fieldValue)
        {
            return fieldValue.ToString();
        }

        private static string Sanitize(string fieldValue)
        {
            if (fieldValue == null)
                return "";

            fieldValue = fieldValue.Replace("\r\n", " ");
            fieldValue = fieldValue.Replace("\n", " ");
            fieldValue = fieldValue.Replace("\r", " ");

            return fieldValue.Replace(";", ",");
        }
    }


}