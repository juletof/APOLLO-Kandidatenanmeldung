using System.Web.Mvc;
using ApolloDb;

namespace Frontend.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly Registrieren _registrieren;
        private readonly KandidatRepository _praktikanteRepo;

        public AccountController(Registrieren registrieren, 
                                 KandidatRepository praktikanteRepo)
        {
            _registrieren = registrieren;
            _praktikanteRepo = praktikanteRepo;
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

            var kandidat = _registrieren.Run(RegistrierungModel2Entity.Run(model));

            return View("Dashboard", new DashboardModel(kandidat));
        }


        public ActionResult Login()
        {
            return View();
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
    }
}