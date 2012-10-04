using System.ComponentModel.DataAnnotations;

namespace ApolloDb
{
    public class PasswortVergessenModel
    {
        public Message Message;

        [Required(ErrorMessage = "* Bitte geben Sie eine Emailadresse ein. | Пожалуйста введите свой электронный адрес.")]
        [RegularExpression(Regexes.Email, ErrorMessage = "Bitte geben Sie eine gültige Emailadresse an. | Пожалуйста введите правильный электронный адрес.")]
        public string Emailadresse { get; set; }

    }
}