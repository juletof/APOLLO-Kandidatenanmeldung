using System.Net.Mail;

namespace ApolloDb
{
    public class Registrieren : IRegisterAsInstancePerLifetime
    {
        private readonly KandidatRepository _kandidatRepository;
        private readonly SendMailMessage _sendMailMessage;
        private readonly StatuswechselLog _statuswechselLog;

        public Registrieren(KandidatRepository kandidatRepository, 
                            SendMailMessage sendMailMessage, 
                            StatuswechselLog statuswechselLog)
        {
            _kandidatRepository = kandidatRepository;
            _sendMailMessage = sendMailMessage;
            _statuswechselLog = statuswechselLog;
        }

        public Kandidat Run(Kandidat kandidat)
        {
            _sendMailMessage.Run(GetMailMessage(kandidat.EmailAdresse));

            kandidat.Status = KandidatStatus.Registriert;
            _kandidatRepository.Create(kandidat);

            _statuswechselLog.Run(kandidat.Id, kandidat.Status);

            return kandidat;
        }

        private MailMessage GetMailMessage(string emailAdresse)
        {
            var mailMessage = new MailMessage();
            mailMessage.To.Add(new MailAddress(emailAdresse));
            mailMessage.Subject = "Registrierung für die APOLLO-Online-Bewerbung | Регистрация для APOLLO электронной подачи заявлений";
            mailMessage.Body = @"Здравствуйте,

Вы успешно прошли регистрацию для электронной подачи заявлений.

Для допуска к участию в собеседовании, внесите все необходимые данные в заявление на участие до 03 ноября 2017 года.

Чтобы войти в систему, перейдите по ссылке: bewerbung.apollo-online.de/account/login.

Нажмите на кнопку 'К заявлению', для ввода необходимых данных.

Спасибо за проявленный интерес!

Коллектив АПОЛЛО

--

Guten Tag,

sie haben sich erfolgreich für die APOLLO-Online-Anmeldung registriert.

Bitte geben Sie bis zum 03. November 2017 die erforderlichen Daten für die Anmeldung zum Auswahlverfahren ein, falls Sie es noch nicht getan haben.

Loggen Sie sich dazu auf folgender Seite mit Ihrer Email-Adresse ein: http://bewerbung.apollo-online.de/account/login.

Gehen Sie dann auf den Link 'Zum Formular', um Ihre Daten einzugeben.

Wir freuen uns auf Ihre Bewerbung!

Das APOLLO-Team

";

            return mailMessage;
        }
    }
}
