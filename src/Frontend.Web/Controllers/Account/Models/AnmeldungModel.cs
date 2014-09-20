using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        Mobilfunknummer = kandidat.Mobilnummer;

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

        IsAdmin = sessionUser.IsLoggedInAdmin;
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

    public string Mobilfunknummer { get; set; }

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
}
