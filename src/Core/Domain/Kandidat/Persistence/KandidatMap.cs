using FluentNHibernate.Mapping;

namespace ApolloDb
{
    public class KandidatMap : ClassMap<Kandidat>
    {
        public KandidatMap()
        {
            Id(x => x.Id);

            Map(x => x.PraktikumsJahr);
            Map(x => x.Geschlecht);
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
            Map(x => x.Kurs);
            Map(x => x.VerkürzterStudiengang);
            Map(x => x.AngestrebterAbschluss);
            
            Map(x => x.Deutschkentnisse);
            Map(x => x.DeutschkentnisseDurchSchule);
            Map(x => x.DeutschkentnisseDurchUni);
            Map(x => x.DeutschkentnisseDurchSonstige);
            
            Map(x => x.FruehererAufenthalt);
            Map(x => x.FruehererAufenthaltProgramm);
            Map(x => x.Kommentar).CustomSqlType("NVARCHAR(max)");

            Map(x => x.Status);

            Map(x => x.DateModified);
            Map(x => x.DateCreated);
        }
    }
}
