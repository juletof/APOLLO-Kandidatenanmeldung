using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace ApolloDb
{
    public class PraktikantMap : ClassMap<Praktikant>
    {
        public PraktikantMap()
        {
            Id(x => x.Id);

            Map(x => x.BewerbungFuer);
            Map(x => x.Anrede);
            Map(x => x.Familienname);
            Map(x => x.FamiliennameKY);
            Map(x => x.Vorname);
            Map(x => x.VornameKY);
            Map(x => x.Vatersname);
            Map(x => x.VatersnameKY);

            Map(x => x.EmailAdresse);
            Map(x => x.Passwort);
            
            Map(x => x.Mobilnummer);
            Map(x => x.Geburtsdatum);
            Map(x => x.NummerInlandspass);
            Map(x => x.Hochschule);
            Map(x => x.Fakultät);
            Map(x => x.Studienfach);
            Map(x => x.Spezialisierung);
            Map(x => x.PraktikumAbStudienjahr);
            Map(x => x.VerkürzterStudiengang);
            Map(x => x.AngestrebterAbschluss);
            
            Map(x => x.Deutschkentnisse);
            Map(x => x.DeutschkentnisseWoGelernt);

            Map(x => x.BereitsAufenthalt);
            Map(x => x.BereitsAufenthaltProgramm);
            Map(x => x.BereitsAufenthaltKommentar);

            Map(x => x.DateModified);
            Map(x => x.DateCreated);
        }
    }
}
