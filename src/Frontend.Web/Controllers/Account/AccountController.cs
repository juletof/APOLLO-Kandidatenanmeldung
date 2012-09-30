using System;
using System.Web.Mvc;
using ApolloDb;

namespace Frontend.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly Registrieren _registrieren;
        private readonly Anmelden _anmelden;
        private readonly KandidatRepository _kandidatRepository;
        private readonly IsEmailAddressInUse _emailAddressInUse;
        private readonly SessionUser _sessionUser;

        public AccountController(Registrieren registrieren, 
                                 Anmelden anmelden,
                                 KandidatRepository kandidatRepository, 
                                 IsEmailAddressInUse emailAddressInUse, 
                                 SessionUser sessionUser)
        {
            _registrieren = registrieren;
            _anmelden = anmelden;
            _kandidatRepository = kandidatRepository;
            _emailAddressInUse = emailAddressInUse;
            _sessionUser = sessionUser;
        }

        public ActionResult Registrierung()
        {
            return View(new RegistrierungModel());
        }

        [HttpPost]
        public ActionResult Registrierung(RegistrierungModel model)
        {
            if(!ModelState.IsValid){
                return View(model);
            }

            if(_emailAddressInUse.Yes(model.Emailadresse))
            {
                model.Message = new ErrorMessage("Die Emailadresse ist bereits in Verwendung | Uebersetzung");
                return View(model);
            }

            var kandidat = _registrieren.Run(RegistrierungModel2Entity.Run(model));

            _sessionUser.Login(kandidat);
            return Redirect("Dashboard/registrierungErfolgreich");
        }

        public ActionResult Login(){ return View(new LoginModel());}

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                return View(loginModel);

            var loginResult = Sl.Resolve<Login>().Run(loginModel.Emailadresse, loginModel.Password);
            if (loginResult.Success)
            {
                _sessionUser.Login(loginResult.Kandidat);
                return Redirect("Dashboard");
            }
            
            loginModel.Message = new ErrorMessage("Die Anmeldedaten sind nicht korrekt");
            return View(loginModel);
        }

        public ActionResult LogOff()
        {
            _sessionUser.Logout();
            return View();
        }

        [AuthorizedOnly]
        public ActionResult Dashboard()
        {
            return View(new DashboardModel(_sessionUser.GetKandidat()));
        }

        [AuthorizedOnly][HttpGet]
        public ActionResult Dashboard(string id)
        {
            var dashboardModel = new DashboardModel(_sessionUser.GetKandidat());
            if (id == "registrierungErfolgreich")
                dashboardModel.ZeigeRegistrierungErfolgreich = true;
            
            if (id == "anmeldungErfolgreich")
                dashboardModel.Message = new SuccessMessage("Danke, Sie haben alle erforderlichen Daten für die Anmeldung eingegeben. Wir werden Sie bald nach Bewerbungsschluss per Email benachrichtigen, ob Sie zum Auswahlgespräch zugelassen sind. <br><br>" +
                                   "Спасибо, вы задали все неодходимые данные для регистрации. Вскоре после окончания срока подачи заявлений мы сообщим вам, по емайлу допущены ли вы к участию в первом собеседовании.");
            
            return View(dashboardModel);
        }

        [AuthorizedOnly]
        public ActionResult Anmeldung()
        {
            return View(new AnmeldungModel(_sessionUser.GetKandidat()));
        }


        [AuthorizedOnly] [HttpPost]
        public ActionResult Anmeldung(AnmeldungModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            DateTime outParseTest;
            if (!DateTime.TryParse(model.Geburtsdatum, out outParseTest))
            {
                model.Message = new ErrorMessage("Das Geburtstdatum kann nicht verarbeitet werden. Bitte achten Sie auf das Eingabeformat: dd-mm-yyyy | Übersetzung Формат: дд-мм-гггг");
                return View(model);
            }

            _anmelden.Run(AnmeldungModelFillFromUi.Run(model, _sessionUser.GetKandidat()));
            return Redirect("Dashboard/anmeldungErfolgreich");
        }

        [AuthorizedOnly]
        public ActionResult Benutzerdaten()
        {
            return View(new BenutzerDatenModel(_sessionUser.GetKandidat()));
        }

        [AuthorizedOnly] [HttpPost]
        public ActionResult Benutzerdaten(BenutzerDatenModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _kandidatRepository.Update(BenutzerDatenModellFillFromUi.Run(model, _sessionUser.GetKandidat()));
            model.Message = new SuccessMessage("Die Daten wurden gespeichert | Uebersetzung");

            return View(model);
        }

        public ActionResult Passwort_vergessen()
        {
            return View(new PasswortVergessenModel());
        }

        [HttpPost]
        public ActionResult Passwort_vergessen(PasswortVergessenModel model)
        {
            var result = Sl.Resolve<PasswortVergessen>().Run(model.Emailadresse);
            if(result.DieEmailExisitertNicht)
                model.Message = new ErrorMessage("Die Email exisistert nicht");
            else if(result.Success)
                model.Message = new SuccessMessage("Eine Benachrichtigung wird verschickt.");

            return View(model);
        }

        [AuthorizedOnly]
        public ActionResult Passwort_aendern()
        {
            return View(new PasswortAendernModel());
        }

        [AuthorizedOnly] [HttpPost]
        public ActionResult Passwort_aendern(PasswortAendernModel passwortAendernModel)
        {
            var kandidat = _sessionUser.GetKandidat();
            var loginResult = Sl.Resolve<Login>().Run(kandidat.EmailAdresse, passwortAendernModel.AltesPasswort);

            if(loginResult.Success)
            {
                kandidat.Passwort = HashPassword.Run(passwortAendernModel.NeuesPasswort1);
                _kandidatRepository.Update(kandidat);
                passwortAendernModel.Message =
                    new SuccessMessage("Sie haben Ihr Passwort erfolgreich geändert. | " +
                                       "Вы успешно изменили пароль");
            }
            else
                passwortAendernModel.Message = new ErrorMessage("Das alte Passwort ist nicht korrekt.");

            return View(passwortAendernModel);
        }

        public ActionResult AutoLogin()
        {
            if (!Request.IsLocal)
                return Redirect("/");

            _sessionUser.Login(_kandidatRepository.GetById(1));
            return RedirectToAction("Dashboard");
        }
    }
}