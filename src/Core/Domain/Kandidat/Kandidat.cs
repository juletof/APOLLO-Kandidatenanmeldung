using System;
using Seedworks.Lib.Persistence;

namespace ApolloDb
{
    public class Kandidat : DomainEntity
    {
        public virtual int PraktikumsJahr { get; set; }
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
        public virtual DateTime? Geburtsdatum { get; set; }
        public virtual string NummerInlandspass { get; set; }
        public virtual int Hochschule { get; set; }
        public virtual string Fakultät { get; set; }
        public virtual int Studienfach { get; set; }
        public virtual string Spezialisierung { get; set; }
        /// <summary>Studienjahr</summary>
        public virtual int Kurs { get; set; }
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

        public Kandidat()
        {
            PraktikumsJahr = 2013;
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
