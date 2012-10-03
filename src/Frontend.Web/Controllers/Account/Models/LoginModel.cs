using System.ComponentModel.DataAnnotations;
using ApolloDb;

public class LoginModel
{
    public Message Message;

    [Required(ErrorMessage = "* Bitte geben Sie eine Emailadresse ein. | Übersetzung")]
    [RegularExpression(Regexes.Email, ErrorMessage = "Bitte geben Sie eine gültige Emailadresse an. | Übersetzung")]
    public string Emailadresse{ get; set; }

    [Required(ErrorMessage = "* Bitte geben Sie ein Password ein. | Übersetzung")]
    public string Password { get; set; }
}
