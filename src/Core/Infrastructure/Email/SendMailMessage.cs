using System.Net;
using System.Net.Mail;

namespace ApolloDb
{
    public class SendMailMessage : IRegisterAsInstancePerLifetime
    {
        public void Run(MailMessage mailMessage)
        {
            mailMessage.From = new MailAddress("otbor@apollo-online.de", "APOLLO e.V.");
            var smtp = new SmtpClient();
            smtp.Send(mailMessage);
        }
    }
}