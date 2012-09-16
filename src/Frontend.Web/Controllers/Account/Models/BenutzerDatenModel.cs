﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ApolloDb;

public class BenutzerDatenModel
{
    public BenutzerDatenModel()
    {
        AnredeOpts = new AnredeWerte().ToSelectItems();
    }

    public Message Message;

    public string AnredeVal;
    public IList<SelectListItem> AnredeOpts;

    [Required(ErrorMessage = "* Pflichtfeld")]
    public string FamiliennameKY { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld")]
    public string VornameKY { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld")]
    public string VatersnameKY { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld")]
    [RegularExpression(Regexes.Email, ErrorMessage = "Bitte geben Sie eine gültige Emailadresse an.")]
    public string Emailadresse { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld")]
    public string Passwort { get; set; }

    [BooleanRequiredToBeTrueAttribute(ErrorMessage = "* Pflichtfeld")]
    public bool AcceptTerms { get; set; }
}