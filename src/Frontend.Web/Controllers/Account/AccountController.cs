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
            return Redirect("Dashboard/anmeldungErfolgreich");
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
            return View(new DashboardModel(_sessionUser.Kandidat));
        }

        [AuthorizedOnly][HttpGet]
        public ActionResult Dashboard(string id)
        {
            var dashboardModel = new DashboardModel(_sessionUser.Kandidat);
            if (id == "anmeldungErfolgreich"){
                dashboardModel.ZeigeRegistrierungErfolgreich = true;
            }

            return View(dashboardModel);
        }

        [AuthorizedOnly]
        public ActionResult Anmeldung()
        {
            return View(new AnmeldungModel(_sessionUser.Kandidat));
        }


        [AuthorizedOnly] [HttpPost]
        public ActionResult Anmeldung(AnmeldungModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _anmelden.Run(AnmeldungModelFillFromUi.Run(model, _sessionUser.Kandidat));

            return View(model);
        }

        [AuthorizedOnly]
        public ActionResult Benutzerdaten()
        {
            return View(new BenutzerDatenModel(_sessionUser.Kandidat));
        }

        [AuthorizedOnly] [HttpPost]
        public ActionResult Benutzerdaten(BenutzerDatenModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _kandidatRepository.Update(BenutzerDatenModellFillFromUi.Run(model, _sessionUser.Kandidat));
            model.Message = new SuccessMessage("Die Daten wurden gespeichert | Uebersetzung");

            return View(model);
        }

        public ActionResult Passwort_vergessen()
        {
            return View();
        }

        [AuthorizedOnly]
        public ActionResult Passwort_aendern()
        {
            return View();
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