using FluentNHibernate.Mapping;

namespace ApolloDb
{
    public class KandidatMap : ClassMap<Kandidat>
    {
        public KandidatMap()
        {
            Id(x => x.Id);

            Map(x => x.Praktikumsjahr);
            Map(x => x.Studienjahr);
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
            Map(x => x.Notfallkontakt);
            Map(x => x.Geburtsdatum);
            Map(x => x.NummerInlandspass);
            Map(x => x.NummerReisepass);
            Map(x => x.Hochschule);
            Map(x => x.Fakultät);
            Map(x => x.Studienfach);
            Map(x => x.Spezialisierung);

            Map(x => x.VerkürzterStudiengang);
            Map(x => x.AngestrebterAbschluss);
            
            Map(x => x.Deutschkentnisse);
            Map(x => x.DeutschkentnisseDurchSchule);
            Map(x => x.DeutschkentnisseDurchUni);
            Map(x => x.DeutschkentnisseDurchSonstige);
            
            Map(x => x.FruehererAufenthalt);
            Map(x => x.FruehererAufenthaltProgramm);
            Map(x => x.Kommentar).CustomSqlType("NVARCHAR(max)");
            Map(x => x.KommentarApollo).CustomSqlType("NVARCHAR(max)");

            Map(x => x.Status);

            Map(x => x.ErfahrungenLandwirtschaft );
            Map(x => x.PraktikumDeutschland );
            Map(x => x.FuehrerscheinPkw );
            Map(x => x.FuehrerscheinTraktor );
            Map(x => x.FuehrerscheinMaehdrescher );
            Map(x => x.FuehrerscheinSonstige );
            Map(x => x.WarumTeilnehmen );
            Map(x => x.BetriebsTypMilchviehhaltung );
            Map(x => x.BetriebsTypSchweinemast );
            Map(x => x.BetriebsTypAckerbau );
            Map(x => x.BetriebsTypGemüsebauObstbau );
            Map(x => x.BetriebsTypWeinbau );
            Map(x => x.BetriebsTypImkerei );
            Map(x => x.BetriebsTypAndere );
            Map(x => x.KoerperlichEinsatzfaehig );
            Map(x => x.Raucher );
            Map(x => x.KoerperlicheEinschraenkungen );
            Map(x => x.IchEsseNicht );
            Map(x => x.FuerArbeitskleidung );

            Map(x => x.DateModified);
            Map(x => x.DateCreated);
        }
    }
}
