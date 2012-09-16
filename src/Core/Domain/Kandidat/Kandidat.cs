using System;
using Seedworks.Lib.Persistence;

namespace ApolloDb
{
    public class Kandidat : DomainEntity
    {
        public virtual int BewerbungFuer { get; set; }
        public virtual int Anrede { get; set; }

        public virtual string Familienname { get; set; }
        public virtual string FamiliennameKY { get; set; }
        public virtual string Vorname { get; set; }
        public virtual string VornameKY { get; set; }
        public virtual string Vatersname { get; set; }
        public virtual string VatersnameKY { get; set; }

        public virtual string EmailAdresse { get; set; }
        public virtual string Passwort { get; set; }

        public virtual string Mobilnummer { get; set; }
        public virtual DateTime? Geburtsdatum { get; set; }
        public virtual string NummerInlandspass { get; set; }
        public virtual int Hochschule { get; set; }
        public virtual string Fakultät { get; set; }
        public virtual int Studienfach { get; set; }
        public virtual string Spezialisierung { get; set; }
        public virtual int PraktikumAbStudienjahr { get; set; }
        public virtual bool VerkürzterStudiengang { get; set; }
        public virtual int AngestrebterAbschluss { get; set; }

        public virtual bool Deutschkentnisse { get; set; }
        public virtual bool DeutschkentnisseDurchSchule { get; set; }
        public virtual bool DeutschkentnisseDurchUni { get; set; }
        public virtual bool DeutschkentnisseDurchSonstige { get; set; }

        public virtual bool BereitsAufenthalt { get; set; }
        public virtual string BereitsAufenthaltProgramm { get; set; }
        public virtual string BereitsAufenthaltKommentar { get; set; }

        public virtual KandidatStatus Status { get; set; }

        public virtual string GetVollerName()
        {
            return Vorname + " " + Vatersname + " " + Familienname;
        }

        public virtual string GetVollerNameKY()
        {
            return FamiliennameKY + "  " + VornameKY + " " + VatersnameKY;
        }
        public virtual string GetAlter()
        {
            if (Geburtsdatum == null)
                return "";

            return Math.Round((DateTime.Now - ((DateTime) Geburtsdatum)).TotalDays/365,0).ToString();
        }
    }
}
