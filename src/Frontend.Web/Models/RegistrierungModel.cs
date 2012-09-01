using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

public class RegistrierungModel
{
    public IList<SelectListItem> Anrede;
    public string FamiliennameKY;
    public string VornameKY;
    public string VatersnameKY;

    public string Emailadresse;
    public string Passwort;
}