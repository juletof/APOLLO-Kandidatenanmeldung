using System;
using Seedworks.Lib.Persistence;

namespace ApolloDb
{
    public class Kandidat : DomainEntity
    {
        public virtual int Praktikumsjahr { get; set; }
        public virtual int Studienjahr { get; set; }
        public virtual int Geschlecht { get; set; }

        public virtual string Familienname { get; set; }
        public virtual string FamiliennameKY { get; set; }
        public virtual string Vorname { get; set; }
        public virtual string VornameKY { get; set; }
        public virtual string Vatersname { get; set; }
        public virtual string VatersnameKY { get; set; }

        public virtual string EmailAdresse { get; set; }
        public virtual string Passwort { get; set; }

        public virtual string Mobilnummer { get; set; }
        public virtual string Notfallkontakt { get; set; }

        public virtual DateTime? Geburtsdatum { get; set; }
        public virtual string NummerInlandspass { get; set; }
        public virtual string NummerReisepass { get; set; }
        public virtual int Hochschule { get; set; }
        public virtual string Fakultät { get; set; }
        public virtual int Studienfach { get; set; }
        public virtual string Spezialisierung { get; set; }

        public virtual bool VerkürzterStudiengang { get; set; }
        public virtual int AngestrebterAbschluss { get; set; }

        public virtual bool Deutschkentnisse { get; set; }
        public virtual bool DeutschkentnisseDurchSchule { get; set; }
        public virtual bool DeutschkentnisseDurchUni { get; set; }
        public virtual bool DeutschkentnisseDurchSonstige { get; set; }

        public virtual bool FruehererAufenthalt { get; set; }
        public virtual string FruehererAufenthaltProgramm { get; set; }

        public virtual string Kommentar { get; set; }
        public virtual string KommentarApollo { get; set; }

        public virtual KandidatStatus Status { get; set; }

        public virtual string ErfahrungenLandwirtschaft { get; set; }
        public virtual string PraktikumDeutschland { get; set; }
        public virtual bool FuehrerscheinPkw { get; set; }
        public virtual bool FuehrerscheinTraktor { get; set; }
        public virtual bool FuehrerscheinMaehdrescher { get; set; }
        public virtual bool FuehrerscheinSonstige { get; set; }
        public virtual string WarumTeilnehmen { get; set; }
        public virtual bool BetriebsTypMilchviehhaltung { get; set; }
        public virtual bool BetriebsTypSchweinemast { get; set; }
        public virtual bool BetriebsTypAckerbau { get; set; }
        public virtual bool BetriebsTypGemüsebauObstbau { get; set; }
        public virtual bool BetriebsTypWeinbau { get; set; }
        public virtual bool BetriebsTypImkerei { get; set; }
        public virtual string BetriebsTypAndere { get; set; }
        public virtual bool KoerperlichEinsatzfaehig { get; set; }
        public virtual bool Raucher { get; set; }
        public virtual string KoerperlicheEinschraenkungen { get; set; }
        public virtual string IchEsseNicht { get; set; }
        public virtual string Groesse { get; set; }
        public virtual string Schuhgroesse { get; set; }
        public virtual string Konfektionsgroesse { get; set; }

        public Kandidat()
        {
            Praktikumsjahr = Consts.LaufendesPraktikumsjahr;
        }
        
        public virtual string GetVollerName()
        {
            return Vorname + " " + Familienname;
        }

        public virtual string GetVollerNameKY()
        {
            return VornameKY + " " + FamiliennameKY;
        }
        public virtual string GetAlter()
        {
            if (Geburtsdatum == null)
                return "";

            return Math.Round((DateTime.Now - ((DateTime) Geburtsdatum)).TotalDays/365,0).ToString();
        }

    }
}
