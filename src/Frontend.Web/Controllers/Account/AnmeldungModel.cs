using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApolloDb;

public class AnmeldungModel
{
    public AnmeldungModel()
    {
        Familienname = "asdfasdf";
        UniOps = Universitaeten.ToSelectItems();
    }

    [Required(ErrorMessage = "* Pflichtfeld")]
    public string Familienname { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld")]
    public string Vorname { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld")]
    public DateTime Geburtsdatum{ get; set; }

    [Required(ErrorMessage = "* Pflichtfeld")]
    public string Inlandspass { get; set; }

    public string Mobilfunknummer { get; set; }

    public string UniVal;
    public IList<SelectListItem> UniOps;

}
