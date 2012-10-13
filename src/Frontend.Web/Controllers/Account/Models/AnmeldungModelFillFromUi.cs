using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ApolloDb
{
    public class AnmeldungModelFillFromUi
    {
        public static Kandidat Run(AnmeldungModel anmeldungModel, Kandidat kandidat)
        {
            kandidat.Familienname = anmeldungModel.Familienname;
            kandidat.Vorname = anmeldungModel.Vorname;
            kandidat.Geburtsdatum = DateTime.Parse(anmeldungModel.Geburtsdatum, CultureInfo.GetCultureInfo("de-DE"));
            kandidat.NummerInlandspass = anmeldungModel.Inlandspass;
            kandidat.Mobilnummer = anmeldungModel.Mobilfunknummer;
            kandidat.Hochschule = Convert.ToInt32(anmeldungModel.UniVal);
            kandidat.Fakultät = anmeldungModel.Fakultaet;
            kandidat.Spezialisierung = anmeldungModel.Studienfach;
            kandidat.Studienfach = Convert.ToInt32(anmeldungModel.StudienfachVal);
            kandidat.PraktikumsJahr = Convert.ToInt32(anmeldungModel.StudienJahrVal);
            kandidat.VerkürzterStudiengang = anmeldungModel.VerkürzterStudiengang;
            kandidat.AngestrebterAbschluss = Convert.ToInt32(anmeldungModel.AngestrebterAbschlussVal);
            kandidat.Deutschkentnisse = anmeldungModel.Deutschkentnisse;
            kandidat.DeutschkentnisseDurchSchule = anmeldungModel.DeutschkentnisseDurchSchule;
            kandidat.DeutschkentnisseDurchUni = anmeldungModel.DeutschkentnisseDurchUni;
            kandidat.DeutschkentnisseDurchSonstige = anmeldungModel.DeutschkentnisseDurchSonstige;
            kandidat.FruehererAufenthalt = anmeldungModel.BereitsAufenthalt;
            kandidat.FruehererAufenthaltProgramm = anmeldungModel.BereitsAufenthaltProgramm;
            kandidat.Kommentar = anmeldungModel.Kommentar;
            kandidat.KommentarApollo = anmeldungModel.KommentarApollo;

            return kandidat;
        }
    }
}