using System.ComponentModel.DataAnnotations;
using ApolloDb;


public class KontaktModel
{
    public Message Message;

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    public string Text { get; set; }

    [Required(ErrorMessage = "* Pflichtfeld | Обязательное поле")]
    [RegularExpression(Regexes.Email, ErrorMessage = "Bitte geben Sie eine gültige Emailadresse an. | Пожалуйста введите правильный электронный адрес.")]
    public string Email { get; set; }
}
