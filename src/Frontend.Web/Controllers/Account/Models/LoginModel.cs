using System.ComponentModel.DataAnnotations;
using ApolloDb;

public class LoginModel
{
    public Message Message;

    [Required(ErrorMessage = "* Bitte geben Sie eine Emailadresse ein.")]
    [RegularExpression(Regexes.Email, ErrorMessage = "Bitte geben Sie eine gültige Emailadresse an.")]
    public string Emailadresse{ get; set; }

    [Required(ErrorMessage = "* Bitte geben Sie ein Password ein.")]
    public string Password { get; set; }
}
