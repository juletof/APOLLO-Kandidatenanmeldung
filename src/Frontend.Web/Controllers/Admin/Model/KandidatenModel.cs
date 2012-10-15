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

        var allStatusWechsel = Sl.Resolve<StatuswechselRepository>().GetAll();

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
                Kurs = studienJahre.GermanLabel(item.PraktikumsJahr, ""),
                Mobilnummer = item.Mobilnummer,
                Status = item.Status,
                StatusSeit = allStatusWechsel
                                .Where(x => x.KandidatId == item.Id)
                                .OrderByDescending(x => x.Zeitpunkt)
                                .First().Zeitpunkt.ToString("dd.MM.yyy HH:mm:ss"),
                StatusHistorie = allStatusWechsel
                                    .Where(x => x.KandidatId == item.Id)
                                    .OrderByDescending(x => x.Zeitpunkt)
                                    .Select(x => NiceLabel(x.Status) + ": " + x.Zeitpunkt.ToString("dd.MM.yyy HH:mm:ss"))
                                    .Aggregate((x,y) => x + "<br/>" + y),
                StatusText = NiceLabel(item.Status),
                AltersWarnung = item.GetAlter() != "" && Convert.ToInt32(item.GetAlter()) < 20, 
                KommentarApollo = item.KommentarApollo,
                KommentarKandidat = item.Kommentar
            }).ToList();
    }

    private string NiceLabel(KandidatStatus status)
    {
        if (status == KandidatStatus.Registriert)
            return "Registriert";
        if (status == KandidatStatus.AnmeldungVollstaendig)
            return "Vollständig";
        if (status == KandidatStatus.Zugelassen)
            return "Zugelassen";

        return "Unbekannter Status";
    }
}
