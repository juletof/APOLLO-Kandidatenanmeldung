using System.Web.Mvc;
using ApolloDb;

namespace Frontend.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly Registrieren _registrieren;
        private readonly KandidatRepository _praktikanteRepo;
        private readonly IsEmailAddressInUse _emailAddressInUse;
        private readonly SessionUser _sessionUser;

        public AccountController(Registrieren registrieren, 
                                 KandidatRepository praktikanteRepo, 
                                 IsEmailAddressInUse emailAddressInUse, 
                                 SessionUser sessionUser)
        {
            _registrieren = registrieren;
            _praktikanteRepo = praktikanteRepo;
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

            return View("Dashboard", new DashboardModel(kandidat));
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
                return RedirectToAction("Dashboard");
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

        [AuthorizedOnly]
        public ActionResult Anmeldung()
        {
            return View();
        }

        [HttpPost]
        [AuthorizedOnly]
        public ActionResult Anmeldung(AnmeldungModel model)
        {
            return View(model);
        }

        [AuthorizedOnly]
        public ActionResult Benutzerdaten()
        {
            return View();
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
    }
}