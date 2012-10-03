using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ApolloDb;

public class BenutzerDatenModel
{
    public BenutzerDatenModel()
    {
        AnredeOpts = new AnredeWerte().ToSelectItems();
    }

    public BenutzerDatenModel(Kandidat kandidat)
    {
        AnredeOpts = new AnredeWerte().ToSelectItems(kandidat.Geschlecht);
        FamiliennameKY = kandidat.FamiliennameKY;
        VornameKY = kandidat.VornameKY;
        VatersnameKY = kandidat.VatersnameKY;
        Emailadresse = kandidat.EmailAdresse;
    }

    public Message Message;

    public string AnredeVal { get; set; }
    public IList<SelectListItem> AnredeOpts;

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public string FamiliennameKY { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public string VornameKY { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public string VatersnameKY { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    [RegularExpression(Regexes.Email, ErrorMessage = "Bitte geben Sie eine gültige Emailadresse an. | Übersetzung")]
    public string Emailadresse { get; set; }
}