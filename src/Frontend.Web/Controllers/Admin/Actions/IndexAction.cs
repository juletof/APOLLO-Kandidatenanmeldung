﻿using System;
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
            searchSpec.Filter.Stati.Add(KandidatStatus.NichtDefiniert);

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
                Sl.Resolve<StatusStatistikLaden>().Run(Convert.ToInt32(model.FilterUniVal))
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
            return csvId.Split(',')
                        .Select(x => Convert.ToInt32(x));
        }

    }
}