using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ApolloDb;
using ApolloDb.Domain.Kandidat.Lists;

public class AnmeldungModel
{
    public AnmeldungModel()
    {
        UniOps = new Universitaeten().ToSelectItems();
        StudienfachOps = new Studienfaecher().ToSelectItems();
        StudienJahrOps = new Studienjahr().ToSelectItems();
        AngestrebterAbschlussOps = new Abschluesse().ToSelectItems();
    }

    [Required(ErrorMessage = "* Pflichtfeld")]
    public string Familienname { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld")]
    public string Vorname { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld")]
    public string Geburtsdatum{ get; set; }

    [Required(ErrorMessage = "* Pflichtfeld")]
    public string Inlandspass { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld")]
    public string Mobilfunknummer { get; set; }

    public string UniVal { get; set; }
    public IList<SelectListItem> UniOps;

    [Required(ErrorMessage = "* Pflichtfeld")]
    public string Fakultaet { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld")]
    public string Studienfach { get; set; }

    public IList<SelectListItem> StudienfachOps;
    public string StudienfachVal { get; set; }

    public IEnumerable<SelectListItem> StudienJahrOps;
    public object StudienJahrVal { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld")]
    public bool VerkürzterStudiengang { get; set; }

    public string AngestrebterAbschlussVal { get; set; }
    public IEnumerable<SelectListItem> AngestrebterAbschlussOps;

    [Required(ErrorMessage = "* Pflichtfeld")]
    public bool Deutschkentnisse { get; set; }

    public bool DeutschkentnisseDurchSchule { get; set; }
    public bool DeutschkentnisseDurchUni { get; set; }
    public bool DeutschkentnisseDurchSonstige { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld")]
    public bool BereitsAufenthalt { get; set; }

    public string BereitsAufenthaltProgramm { get; set; }
    public string BereitsAufenthaltKommentar { get; set; }
}
