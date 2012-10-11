using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ApolloDb;
using ApolloDb.Domain.Kandidat.Lists;

public class KandidatenModel
{
    public bool FilterAusgeschieden { get; set; }
    public bool FilterRegistriert { get; set; }
    public bool FilterDatenVollständig { get; set; }
    public bool FilterZugelassen { get; set; }

    public string FilterUniVal { get; set; }
    public IList<SelectListItem> FilterUniOps;

    public IList<KandidatItemModel> Items;

    public KandidatenModel()
    {
        FilterUniOps = new Universitaeten().ToSelectItems();
    }

    public KandidatenModel(IEnumerable<Kandidat> kandidaten)
    {
        SetKandidaten(kandidaten);
    }

    public void SetKandidaten(IEnumerable<Kandidat> kandidaten)
    {
        var unis = new Universitaeten();
        var faecher = new Studienfaecher();
        var studienJahre = new Studienjahr();
        var abschluesse = new Abschluesse();

        FilterUniOps = unis.ToSelectItems();

        Items = kandidaten.Select(item => new KandidatItemModel
            {
                Id = item.Id,
                Email = item.EmailAdresse,
                Geburtstag = item.Geburtsdatum == null
                                 ? "??.??.???"
                                 : ((DateTime) item.Geburtsdatum).ToString("dd.MM.yyyy") + "(" + item.GetAlter() + ")",
                VollerName = item.GetVollerName(),
                VollerNameKY = item.GetVollerNameKY(),
                Hochschule = unis.GermanLabel(item.Hochschule, ""),
                Studienfach = faecher.GermanLabel(item.Studienfach, ""),
                Abschluss = abschluesse.GermanLabel(item.AngestrebterAbschluss, ""),
                Kurs = studienJahre.GermanLabel(item.Kurs, ""),
                Mobilnummer = item.Mobilnummer,
                Status = item.Status
            }).ToList();
    }
}
