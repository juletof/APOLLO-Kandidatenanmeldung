using System;
using System.Net.Mail;

namespace ApolloDb
{
    public class PasswortVergessen : IRegisterAsInstancePerLifetime
    {
        private readonly IsEmailAddressInUse _emailAddressInUse;
        private readonly SendMailMessage _sendMailMessage;
        private readonly PasswortVergessenTokenRepository _tokenRepository;

        public PasswortVergessen(IsEmailAddressInUse emailAddressInUse, 
                                 SendMailMessage sendMailMessage,
                                 PasswortVergessenTokenRepository tokenRepository)
        {
            _emailAddressInUse = emailAddressInUse;
            _sendMailMessage = sendMailMessage;
            _tokenRepository = tokenRepository;
        }

        public PasswortVergessenResult Run(string email)
        {
            if (!_emailAddressInUse.Yes(email))
                return new PasswortVergessenResult {DieEmailExisitertNicht = true, Success = false};

            var token = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 15);
            var passwortResetUrl = "http://bewerbung.apollo-online.de/home/passwort_reset/" + token;

            _tokenRepository.Create(new PasswortVergessenToken{Email = email, Token = token});
            _sendMailMessage.Run(GetMailMessage(email, passwortResetUrl));

            return new PasswortVergessenResult {Success = true};
        }

        private MailMessage GetMailMessage(string emailAdresse, string passwortResetUrl)
        {
            var mailMessage = new MailMessage();
            mailMessage.To.Add(new MailAddress(emailAdresse));
            mailMessage.Subject =
                "Neues Passwort für die APOLLO-Online-Bewerbung | Новый пароль для входа в систему электронной подачи заявлений";
            mailMessage.Body = @"Если вы забыли пароль для входа в систему, перейдите по ссылке и задайте новый пароль: {0}

Ссылка на получение нового пароля, действительна 72 часа.

--

Falls Sie das Passwort für Ihr Benutzerkonto bei der APOLLO-Online-Bewerbung vergessen haben, folgen Sie bitte diesem Link, um sich ein neues Passwort zu geben: {0}

Der Link ist 72 Stunden lang gültig.

".Replace("{0}", passwortResetUrl);

            return mailMessage;
        }
    }
}
