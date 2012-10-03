using System.ComponentModel.DataAnnotations;

namespace ApolloDb
{
    public class PasswortVergessenModel
    {
        public Message Message;

        [Required(ErrorMessage = "* Bitte geben Sie eine Emailadresse ein. | Übersetzung")]
        [RegularExpression(Regexes.Email, ErrorMessage = "Bitte geben Sie eine gültige Emailadresse an. | Übersetzung")]
        public string Emailadresse { get; set; }

    }
}