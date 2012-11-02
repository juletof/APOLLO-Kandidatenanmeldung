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

    public string FilterFreiText { get; set; }

    public string FilterUniVal { get; set; }

    public int AnzahlAusgeschieden { get; set; }
    public int AnzahlRegistriert { get; set; }
    public int AnzahlDatenVollständig { get; set; }
    public int AnzahlZugelassen { get; set; }

    public string CommandName { get; set; }
    public string CommandParams { get; set; }

    public Message Message;

    public IList<SelectListItem> FilterUniOps;

    public IList<KandidatItemModel> Items;

    public KandidatenModel(){}

    public void SetKandidaten(IEnumerable<Kandidat> kandidaten, StatusStatistikLadenResult statusStatistik)
    {
        AnzahlAusgeschieden = statusStatistik.Ausgeschieden;
        AnzahlRegistriert = statusStatistik.Registriert;
        AnzahlDatenVollständig = statusStatistik.AnmeldungVollstaendig;
        AnzahlZugelassen = statusStatistik.Zugelassen;

        var unis = new Universitaeten();
        var faecher = new Studienfaecher();
        var studienJahre = new Studienjahr();
        var abschluesse = new Abschluesse();

        var allStatusWechsel = Sl.Resolve<StatuswechselRepository>().GetAll();
        var uniStatistiken =  Sl.Resolve<UniStatistikLaden>().Run();
       
        FilterUniOps = new List<SelectListItem>();
        FilterUniOps.Add(new SelectListItem{Text = "Alle", Value = "-1"});
        foreach(var uni in unis.GetItems())
            FilterUniOps.Add(
                new SelectListItem{
                    Text = uni.Deutsch + " (gesamt:" + uniStatistiken.GetUniCount(uni.Key) + ")",
                    Value = uni.Key.ToString()}
            );

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
                AltersWarnung = item.GetAlter() != "" && Convert.ToInt32(item.GetAlter()) < 19, 
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
        if (status == KandidatStatus.Ausgeschieden)
            return "Ausgeschieden";

        return "Unbekannter Status";
    }
}
