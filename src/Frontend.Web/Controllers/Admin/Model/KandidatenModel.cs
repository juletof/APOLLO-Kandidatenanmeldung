using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ApolloDb;

public class KandidatenModel
{
    public IList<SelectListItem> FilterPraktikumsjahrOps;
    public string FilterPraktikumsjahrVal { get; set; }
    
    public bool FilterAusgeschieden { get; set; }
    public bool FilterRegistriert { get; set; }
    public bool FilterDatenVollständig { get; set; }
    public bool FilterZugelassen { get; set; }
    public bool FilterAuswahlBestanden1 { get; set; }
    public bool FilterAuswahlBestanden2 { get; set; }
    public bool FilterReserve { get; set; }

    public string FilterFreiText { get; set; }

    public IList<SelectListItem> FilterUniOps;
    public string FilterUniVal { get; set; }

    public int AnzahlAusgeschieden { get; set; }
    public int AnzahlRegistriert { get; set; }
    public int AnzahlDatenVollständig { get; set; }
    public int AnzahlZugelassen { get; set; }
    public int AnzahlAuswahlBestanden1 { get; set; }
    public int AnzahlAuswahlBestanden2 { get; set; }
    public int AnzahlReserve { get; set; }

    public string CommandName { get; set; }
    public string CommandParams { get; set; }

    public Message Message;

    public IList<KandidatItemModel> Items;

    public KandidatenModel()
    {
        FilterPraktikumsjahrVal = Consts.LaufendesPraktikumsjahr.ToString();
    }

    public void SetKandidaten(IEnumerable<Kandidat> kandidaten, StatusStatistikLadenResult statusStatistik)
    {
        AnzahlAusgeschieden = statusStatistik.Ausgeschieden;
        AnzahlRegistriert = statusStatistik.Registriert;
        AnzahlDatenVollständig = statusStatistik.AnmeldungVollstaendig;
        AnzahlZugelassen = statusStatistik.Zugelassen;
        AnzahlAuswahlBestanden1 = statusStatistik.Auswahl1;
        AnzahlAuswahlBestanden2 = statusStatistik.Auswahl2;
        AnzahlReserve = statusStatistik.Reserve;

        var unis = new Universitaeten();
        var faecher = new Studienfaecher();
        var studienJahre = new Studienjahr();
        var abschluesse = new Abschluesse();

        var allStatusWechsel = Sl.Resolve<StatuswechselRepository>().GetAll();
        var uniStatistiken =  Sl.Resolve<UniStatistikLaden>().Run(Convert.ToInt32(FilterPraktikumsjahrVal));

        FilterPraktikumsjahrOps = new List<SelectListItem>();
        for (int i = Consts.LaufendesPraktikumsjahr; i >= Consts.ErstesPraktikumsjahr; i--)
            FilterPraktikumsjahrOps.Add(new SelectListItem { Text = i.ToString()});
        FilterPraktikumsjahrOps.Add(new SelectListItem { Text = "Alle", Value = "-1" });

        FilterUniOps = new List<SelectListItem>();
        FilterUniOps.Add(new SelectListItem{Text = "Alle", Value = "-1"});
        foreach(var uni in unis.GetItems())
            FilterUniOps.Add(
                new SelectListItem{
                    Text = uni.Deutsch + (uni.IstAktiv ? "" : " --inaktiv--") + " (gesamt:" + uniStatistiken.GetUniCount(uni.Key) + ")",
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
                Studienjahr = studienJahre.GermanLabel(item.Studienjahr, ""),
                Mobilnummer = item.Mobilnummer,
                Notfallkontakt = item.Notfallkontakt,
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
        if (status == KandidatStatus.Auswahl1)
            return "Auswahl 1 best.";
        if (status == KandidatStatus.Auswahl2)
            return "Auswahl 2 best.";
        if (status == KandidatStatus.Reserve)
            return "Reserve";

        return "Unbekannter Status";
    }
}
