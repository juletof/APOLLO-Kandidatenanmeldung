﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;
using System.Web.Mvc;
using ApolloDb;

public class AnmeldungModel
{
    public AnmeldungModel()
    {
        UniOps = new Universitaeten().ToSelectItems(onlyActive: true);
        StudienfachOps = new Studienfaecher().ToSelectItems();
        StudienJahrOps = new Studienjahr().ToSelectItems();
        AngestrebterAbschlussOps = new Abschluesse().ToSelectItems();
    }

    public AnmeldungModel(Kandidat kandidat, SessionUser sessionUser)
    {
        UniOps = new Universitaeten().ToSelectItems(kandidat.Hochschule, onlyActive: true);
        StudienfachOps = new Studienfaecher().ToSelectItems(kandidat.Studienfach);
        StudienJahrOps = new Studienjahr().ToSelectItems(kandidat.Studienjahr);
        AngestrebterAbschlussOps = new Abschluesse().ToSelectItems(kandidat.AngestrebterAbschluss);

        Familienname = kandidat.Familienname;
        Vorname = kandidat.Vorname;
        if (kandidat.Geburtsdatum != null)
        Geburtsdatum = ((DateTime)kandidat.Geburtsdatum).ToString("dd-MM-yyyy");
        Inlandspass = kandidat.NummerInlandspass;
        Reisepass = kandidat.NummerReisepass;
        Mobilfunknummer = kandidat.Mobilnummer;
        Notfallkontakt = kandidat.Notfallkontakt;
        Fakultaet = kandidat.Fakultät;  
        Studienfach = kandidat.Spezialisierung;
        VerkürzterStudiengang = kandidat.VerkürzterStudiengang;
        Deutschkentnisse = kandidat.Deutschkentnisse;
        DeutschkentnisseDurchSchule = kandidat.DeutschkentnisseDurchSchule;
        DeutschkentnisseDurchUni = kandidat.DeutschkentnisseDurchUni;
        DeutschkentnisseDurchSonstige = kandidat.DeutschkentnisseDurchSonstige;

        BereitsAufenthalt = kandidat.FruehererAufenthalt;

        BereitsAufenthaltProgramm = kandidat.FruehererAufenthaltProgramm;
        Kommentar = kandidat.Kommentar;
        KommentarApollo = kandidat.KommentarApollo;

        ErfahrungenLandwirtschaft = kandidat.ErfahrungenLandwirtschaft;
        PraktikumDeutschland = kandidat.PraktikumDeutschland;
        FuehrerscheinPkw = kandidat.FuehrerscheinPkw;
        FuehrerscheinTraktor = kandidat.FuehrerscheinTraktor;
        FuehrerscheinMaehdrescher = kandidat.FuehrerscheinMaehdrescher;
        FuehrerscheinSonstige = kandidat.FuehrerscheinSonstige;
        WarumTeilnehmen = kandidat.WarumTeilnehmen;
        BetriebsTypMilchviehhaltung = kandidat.BetriebsTypMilchviehhaltung;
        BetriebsTypSchweinemast = kandidat.BetriebsTypSchweinemast;
        BetriebsTypAckerbau = kandidat.BetriebsTypAckerbau;
        BetriebsTypGemüsebauObstbau = kandidat.BetriebsTypGemüsebauObstbau;
        BetriebsTypWeinbau = kandidat.BetriebsTypWeinbau;
        BetriebsTypImkerei = kandidat.BetriebsTypImkerei;
        BetriebsTypAndere = kandidat.BetriebsTypAndere;
        KoerperlichEinsatzfaehig = kandidat.KoerperlichEinsatzfaehig;
        Raucher = kandidat.Raucher;
        KoerperlicheEinschraenkungen = kandidat.KoerperlicheEinschraenkungen;
        IchEsseNicht = kandidat.IchEsseNicht;
        Groesse = kandidat.Groesse;
        Schuhgroesse = kandidat.Schuhgroesse;
        Konfektionsgroesse = kandidat.Konfektionsgroesse;

        IsAdmin = sessionUser.IsLoggedInAdmin;

        ImagePath = KandidatBild.Url(kandidat);
    }

    public Message Message;

    public bool IsAdmin { get; set; }
    
    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public string Familienname { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public string Vorname { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    [RegularExpression(@"[0-3][0-9]-[0-1][0-9]-[1-9][0-9][0-9][0-9]", ErrorMessage = "Format: dd-mm-yyyy | Формат: дд-мм-гггг")]
    public string Geburtsdatum{ get; set; }

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public string Inlandspass { get; set; }
    
    public string Reisepass { get; set; }

    public string Mobilfunknummer { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public string Notfallkontakt { get; set; }

    public string UniVal { get; set; }
    public IList<SelectListItem> UniOps;

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public string Fakultaet { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public string Studienfach { get; set; }

    public IList<SelectListItem> StudienfachOps;
    public string StudienfachVal { get; set; }

    public IEnumerable<SelectListItem> StudienJahrOps;
    public string StudienJahrVal { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public bool VerkürzterStudiengang { get; set; }

    public string AngestrebterAbschlussVal { get; set; }
    public IEnumerable<SelectListItem> AngestrebterAbschlussOps;

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public bool Deutschkentnisse { get; set; }

    public bool DeutschkentnisseDurchSchule { get; set; }
    public bool DeutschkentnisseDurchUni { get; set; }
    public bool DeutschkentnisseDurchSonstige { get; set; }

    public bool BereitsAufenthalt { get; set; }

    public string BereitsAufenthaltProgramm { get; set; }
    public string Kommentar { get; set; }
    public string KommentarApollo { get; set; }

    [BooleanRequiredToBeTrueAttribute(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public bool AcceptTerms { get; set; }

    [BooleanRequiredToBeTrueAttribute(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public bool KenntnisnahmeDatenschutz { get; set; }

    public string ErfahrungenLandwirtschaft { get; set; }
    public string PraktikumDeutschland { get; set; }
    public bool FuehrerscheinPkw { get; set; }
    public bool FuehrerscheinTraktor { get; set; }
    public bool FuehrerscheinMaehdrescher { get; set; }
    public bool FuehrerscheinSonstige { get; set; }
    public string WarumTeilnehmen { get; set; }
    public bool BetriebsTypMilchviehhaltung { get; set; }
    public bool BetriebsTypSchweinemast { get; set; }
    public bool BetriebsTypAckerbau { get; set; }
    public bool BetriebsTypGemüsebauObstbau { get; set; }
    public bool BetriebsTypWeinbau { get; set; }
    public bool BetriebsTypImkerei { get; set; }
    public string BetriebsTypAndere { get; set; }
    public bool KoerperlichEinsatzfaehig { get; set; }
    public bool Raucher { get; set; }
    public string KoerperlicheEinschraenkungen { get; set; }
    public string IchEsseNicht { get; set; }
    public string Groesse { get; set; }
    public string Schuhgroesse { get; set; }
    public string Konfektionsgroesse { get; set; }
    public HttpPostedFileBase Foto { get; set; }
    public string ImagePath { get; set; } = "#";
}
