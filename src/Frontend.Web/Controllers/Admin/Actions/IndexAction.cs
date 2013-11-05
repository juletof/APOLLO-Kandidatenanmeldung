using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ApolloDb
{
    public class IndexAction : IRegisterAsInstancePerLifetime
    {
        private readonly KandidatRepository _kandidatRepo;
        private readonly KandidatLoeschen _kandidatLoeschen;
        private readonly Statuswechseln _statuswechseln;

        public IndexAction(KandidatRepository kandidatRepo, 
                           KandidatLoeschen kandidatLoeschen,
                           Statuswechseln statuswechseln)
        {
            _kandidatRepo = kandidatRepo;
            _kandidatLoeschen = kandidatLoeschen;
            _statuswechseln = statuswechseln;
        }

        public KandidatenModel Run(KandidatenModel model)
        {
            var searchSpec = new KandidatSearchSpec();

            if (model.FilterZugelassen) searchSpec.Filter.Stati.Add(KandidatStatus.Zugelassen);
            if (model.FilterRegistriert) searchSpec.Filter.Stati.Add(KandidatStatus.Registriert);
            if (model.FilterDatenVollständig) searchSpec.Filter.Stati.Add(KandidatStatus.AnmeldungVollstaendig);
            if (model.FilterAusgeschieden) searchSpec.Filter.Stati.Add(KandidatStatus.Ausgeschieden);
            if (model.FilterAuswahlBestanden1) searchSpec.Filter.Stati.Add(KandidatStatus.Auswahl1);
            if (model.FilterAuswahlBestanden2) searchSpec.Filter.Stati.Add(KandidatStatus.Auswahl2);
            if (model.FilterReserve) searchSpec.Filter.Stati.Add(KandidatStatus.Reserve);

            searchSpec.Filter.Stati.Add(KandidatStatus.NichtDefiniert);

            if (model.FilterPraktikumsjahrVal == null || model.FilterPraktikumsjahrVal == "-1")
                searchSpec.Filter.Praktikumsjahr.Reset();
            else
                searchSpec.Filter.Praktikumsjahr.EqualTo(model.FilterPraktikumsjahrVal);

            if (model.FilterUniVal == null || model.FilterUniVal == "-1")
                searchSpec.Filter.Uni.Reset();
            else
                searchSpec.Filter.Uni.EqualTo(model.FilterUniVal);

            if (String.IsNullOrEmpty(model.FilterFreiText))
                searchSpec.Filter.TextSearch.Clear();
            else
                searchSpec.Filter.TextSearch.AddTerms(model.FilterFreiText);

            if (model.CommandName == "kandidatenZulassen")
                KandidatenZulassen(model);

            if (model.CommandName == "kandidatenAusschliessen")
                KandidatenAusschliessen(model);

            if (model.CommandName == "kandidatenLoeschen")
                KandidatenLoeschen(model);
            
            model.SetKandidaten(
                _kandidatRepo.GetBy(searchSpec),
                Sl.Resolve<StatusStatistikLaden>().Run(Convert.ToInt32(model.FilterUniVal), Convert.ToInt32(model.FilterPraktikumsjahrVal))
                );
            
            return model;
        }

        public void KandidatenZulassen(KandidatenModel model)
        {
            var kandidaten = _kandidatRepo.GetByIds(GetIds(model.CommandParams).ToArray());
            foreach (var kandidat in kandidaten)
                _statuswechseln.Run(kandidat.Id, KandidatStatus.Zugelassen);

            Command(model, kandidaten, "Folgende Kandidaten wurden zugelassen: ");
        }

        private void KandidatenAusschliessen(KandidatenModel model)
        {
            var kandidaten = _kandidatRepo.GetByIds(GetIds(model.CommandParams).ToArray());
            foreach (var kandidat in kandidaten)
                _statuswechseln.Run(kandidat.Id, KandidatStatus.Ausgeschieden);

            Command(model, kandidaten, "Folgende Kandidaten wurden ausgeschlossen: ");
        }

        private void KandidatenLoeschen(KandidatenModel model)
        {
            var kandidaten = _kandidatRepo.GetByIds(GetIds(model.CommandParams).ToArray());
            foreach (var kandidat in kandidaten)
                _kandidatLoeschen.Run(kandidat.Id);

            Command(model, kandidaten, "Folgende Kandidaten wurden gelöscht: ");
        }

        private void Command(KandidatenModel model, IEnumerable<Kandidat> kandidaten, string benutzerNachricht)
        {
            model.Message = new SuccessMessage(benutzerNachricht + 
                kandidaten.Select(x => x.GetVollerName()).Aggregate((a,b) => a + ", " + b));
            model.CommandName = "";
            model.CommandParams = "";
        }

        public static IEnumerable<int> GetIds(string csvId)
        {
            if (string.IsNullOrEmpty(csvId))
                return new List<int>(){-1}; 
            
            return csvId.Split(',')
                        .Select(x => Convert.ToInt32(x));
        }

    }
}