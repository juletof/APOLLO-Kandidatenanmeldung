using System.ComponentModel.DataAnnotations;
using ApolloDb;

public class LoginModel
{
    public Message Message;

    [Required(ErrorMessage = "* Bitte geben Sie eine Emailadresse ein. | Пожалуйста введите свой электронный адрес.")]
    [RegularExpression(Regexes.Email, ErrorMessage = "Bitte geben Sie eine gültige Emailadresse an. | Пожалуйста введите правильный электронный адрес.")]
    public string Emailadresse{ get; set; }

    [Required(ErrorMessage = "* Bitte geben Sie ein Password ein. | Пожалуйста введите свой пароль.")]
    public string Password { get; set; }
}
