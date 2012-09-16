using System.Net.Mail;

namespace ApolloDb
{
    public class Registrieren : IRegisterAsInstancePerLifetime
    {
        private readonly KandidatRepository _kandidatRepository;
        private readonly SendMailMessage _sendMailMessage;

        public Registrieren(KandidatRepository kandidatRepository, 
                            SendMailMessage sendMailMessage)
        {
            _kandidatRepository = kandidatRepository;
            _sendMailMessage = sendMailMessage;
        }

        public Kandidat Run(Kandidat kandidat)
        {
            _sendMailMessage.Run(GetMailMessage(kandidat.EmailAdresse));

            kandidat.Status = KandidatStatus.Registriert;
            _kandidatRepository.Create(kandidat);
            return kandidat;
        }

        private MailMessage GetMailMessage(string emailAdresse)
        {
            var mailMessage = new MailMessage();
            mailMessage.To.Add(new MailAddress(emailAdresse));
            mailMessage.From = new MailAddress("bewerbung@apollo-verein.de"); 
            mailMessage.Subject = "Danke für Deine Registrierung";
            mailMessage.Body = @"Schön dass Du Dich registriert hast. 
Als nächstes geht es hier weiter: http://bewerbung.apollo-verein.de";

            return mailMessage;
        }
    }
}
