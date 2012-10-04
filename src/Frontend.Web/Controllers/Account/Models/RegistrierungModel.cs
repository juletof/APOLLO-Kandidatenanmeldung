using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ApolloDb;

public class RegistrierungModel
{
    public RegistrierungModel()
    {
        AnredeOpts = new AnredeWerte().ToSelectItems();
    }

    public Message Message;

    public string AnredeVal { get; set;  }
    public IList<SelectListItem> AnredeOpts;

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public string FamiliennameKY { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public string VornameKY { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public string VatersnameKY { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    [RegularExpression(Regexes.Email, ErrorMessage = "Bitte geben Sie eine gültige Emailadresse an. | Пожалуйста введите правильный электронный адрес.")]
    public string Emailadresse { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public string Passwort { get; set; }

    [BooleanRequiredToBeTrueAttribute(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public bool AcceptTerms { get; set; }

    [BooleanRequiredToBeTrueAttribute(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public bool ReadInformation { get; set; }
}