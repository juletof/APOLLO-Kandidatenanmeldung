using System;
using System.Net.Mail;
using System.Web.Mvc;
using ApolloDb;

namespace Frontend.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public EmptyResult ThrowEx()
        {
            throw new Exception("Test exception");
        }

        public ActionResult Information()
        {
            return View(new InformationModel{ZurueckStartseite = true});
        }

        [HttpGet]
        public ActionResult Information(string id)
        {
            if (id == "vonRegistrierung")
                return View(new InformationModel { ZurueckRegistrierung = true });

            if (id == "vonPersoenlicherBereich")
                return View(new InformationModel { ZurueckPersoenlicherBereich = true });

            return View(new InformationModel { ZurueckStartseite = true });
        }

        [HttpGet]
        public ActionResult passwort_reset(string id)
        {
            var result = Sl.Resolve<PasswortResetVorbereiten>().Run(id);
            var model = new PasswortResetModel {TokenFound = result.Success, Token = id};
            if(!result.Success)
                model.Message = new ErrorMessage("Kein Token gefunden.");

            return View(model);
        }

        [HttpPost]
        public ActionResult passwort_reset(PasswortResetModel model)
        {
            var result = Sl.Resolve<PasswortResetVorbereiten>().Run(model.Token);

            var kandidatRepo = Sl.Resolve<KandidatRepository>();
            var kandidat = kandidatRepo.GetByEmail(result.Email);

            kandidat.Passwort = HashPassword.Run(model.NeuesPasswort1);
            kandidatRepo.Update(kandidat);

            Sl.Resolve<SessionUser>().Login(kandidat);

            return Redirect("/Account/Dashboard/passwortGeaendert");
        }

        public ActionResult Information_Praktikum()
        {
            return View();
        }

        public ActionResult Kontakt()
        {
            var session = Sl.Resolve<SessionUser>();
            if (session.IsLoggedIn)
                return View(new KontaktModel {Email = session.GetKandidat().EmailAdresse});

            return View(new KontaktModel());
        }

        [HttpPost]
        public ActionResult Kontakt(KontaktModel kontaktModel)
        {
            if (!ModelState.IsValid)
            {
                kontaktModel.Message = new ErrorMessage("Die Eingaben sind nicht vollständig. | Übersetzung");
                return View(kontaktModel);
            }

            var mailMessage = new MailMessage();
            mailMessage.To.Add(new MailAddress("otbor@apollo-online.de"));
            mailMessage.Subject = "KONTAKT-NACHRICHT";
            mailMessage.Body = "VON: " + kontaktModel.Email + Environment.NewLine + Environment.NewLine + kontaktModel.Text;
            Sl.Resolve<SendMailMessage>().Run(mailMessage);

            kontaktModel.Message = new SuccessMessage("Vielen Dank! Die Nachricht wurde übermittelt. | Übersetzung");
            return View(kontaktModel);
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}
