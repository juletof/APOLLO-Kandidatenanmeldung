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
            model.Message =
                new SuccessMessage("Sie haben Ihr Passwort erfolgreich geändert. | " +
                                   "Вы успешно изменили пароль");

            return View(model);
        }

        public ActionResult Information_Praktikum()
        {
            return View();
        }
    }
}
