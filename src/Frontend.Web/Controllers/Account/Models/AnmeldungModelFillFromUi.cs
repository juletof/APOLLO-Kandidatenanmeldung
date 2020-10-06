using System;
using System.Globalization;

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
            kandidat.NummerReisepass = anmeldungModel.Reisepass;
            kandidat.Mobilnummer = anmeldungModel.Mobilfunknummer;
            kandidat.Notfallkontakt = anmeldungModel.Notfallkontakt;
            kandidat.Hochschule = Convert.ToInt32(anmeldungModel.UniVal);
            kandidat.Fakultät = anmeldungModel.Fakultaet;
            kandidat.Spezialisierung = anmeldungModel.Studienfach;
            kandidat.Studienfach = Convert.ToInt32(anmeldungModel.StudienfachVal);
            kandidat.Studienjahr = Convert.ToInt32(anmeldungModel.StudienJahrVal);
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

            kandidat.ErfahrungenLandwirtschaft = anmeldungModel.ErfahrungenLandwirtschaft;
            kandidat.PraktikumDeutschland = anmeldungModel.PraktikumDeutschland;
            kandidat.FuehrerscheinPkw = anmeldungModel.FuehrerscheinPkw;
            kandidat.FuehrerscheinTraktor = anmeldungModel.FuehrerscheinTraktor;
            kandidat.FuehrerscheinMaehdrescher = anmeldungModel.FuehrerscheinMaehdrescher;
            kandidat.FuehrerscheinSonstige = anmeldungModel.FuehrerscheinSonstige;
            kandidat.WarumTeilnehmen = anmeldungModel.WarumTeilnehmen;
            kandidat.BetriebsTypMilchviehhaltung = anmeldungModel.BetriebsTypMilchviehhaltung;
            kandidat.BetriebsTypSchweinemast = anmeldungModel.BetriebsTypSchweinemast;
            kandidat.BetriebsTypAckerbau = anmeldungModel.BetriebsTypAckerbau;
            kandidat.BetriebsTypGemüsebauObstbau = anmeldungModel.BetriebsTypGemüsebauObstbau;
            kandidat.BetriebsTypWeinbau = anmeldungModel.BetriebsTypWeinbau;
            kandidat.BetriebsTypImkerei = anmeldungModel.BetriebsTypImkerei;
            kandidat.BetriebsTypAndere = anmeldungModel.BetriebsTypAndere;
            kandidat.KoerperlichEinsatzfaehig = anmeldungModel.KoerperlichEinsatzfaehig;
            kandidat.Raucher = anmeldungModel.Raucher;
            kandidat.KoerperlicheEinschraenkungen = anmeldungModel.KoerperlicheEinschraenkungen;
            kandidat.IchEsseNicht = anmeldungModel.IchEsseNicht;
            
            kandidat.Groesse = anmeldungModel.Groesse;
            kandidat.Schuhgroesse = anmeldungModel.Schuhgroesse;
            kandidat.Konfektionsgroesse = anmeldungModel.Konfektionsgroesse;

            return kandidat;
        }
    }
}