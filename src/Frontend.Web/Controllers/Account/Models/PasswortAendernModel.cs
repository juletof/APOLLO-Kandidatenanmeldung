
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ApolloDb;

public class PasswortAendernModel
{
    public Message Message;

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public string AltesPasswort { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    [Compare("NeuesPasswort2", ErrorMessage = "Die Passwörter stimmen nicht über ein. | Übersetzung")]
    public string NeuesPasswort1 { get; set; }
    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public string NeuesPasswort2 { get; set; }
}
