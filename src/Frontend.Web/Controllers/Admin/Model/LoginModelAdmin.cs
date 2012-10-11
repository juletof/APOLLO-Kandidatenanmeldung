using System.ComponentModel.DataAnnotations;
using ApolloDb;

public class LoginModelAdmin
{
    public Message Message;

    [Required(ErrorMessage = "* Bitte gib einen Nutzernamen ein.")]
    public string Nutzername { get; set; }

    [Required(ErrorMessage = "* Bitte gib ein Password ein.")]
    public string Password { get; set; }
}
