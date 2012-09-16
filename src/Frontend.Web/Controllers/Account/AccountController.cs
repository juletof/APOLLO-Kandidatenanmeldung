using System.Web.Mvc;
using ApolloDb;

namespace Frontend.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly Registrieren _registrieren;
        private readonly KandidatRepository _praktikanteRepo;
        private readonly IsEmailAddressInUse _emailAddressInUse;

        public AccountController(Registrieren registrieren, 
                                 KandidatRepository praktikanteRepo, 
                                 IsEmailAddressInUse emailAddressInUse)
        {
            _registrieren = registrieren;
            _praktikanteRepo = praktikanteRepo;
            _emailAddressInUse = emailAddressInUse;
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
                return View("Dashboard");
            else
            {
                loginModel.Message = new ErrorMessage("Die Anmeldedaten sind nicht korrekt");
                return View(loginModel);
            }
                

            return View(loginModel);
        }

        public ActionResult Dashboard()
        {
            return View(new DashboardModel(_praktikanteRepo.GetById(1)));
        }

        public ActionResult Anmeldung()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Anmeldung(AnmeldungModel model)
        {
            return View(model);
        }

        public ActionResult Benutzerdaten()
        {
            return View();
        }

        public ActionResult Passwort_vergessen()
        {
            return View();
        }

        public ActionResult Passwort_aendern()
        {
            return View();
        }
    }
}