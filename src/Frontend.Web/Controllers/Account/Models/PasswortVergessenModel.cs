using System.ComponentModel.DataAnnotations;

namespace ApolloDb
{
    public class PasswortVergessenModel
    {
        public Message Message;

        [Required(ErrorMessage = "* Bitte geben Sie eine Emailadresse ein.")]
        [RegularExpression(Regexes.Email, ErrorMessage = "Bitte geben Sie eine gültige Emailadresse an.")]
        public string Emailadresse { get; set; }

    }
}