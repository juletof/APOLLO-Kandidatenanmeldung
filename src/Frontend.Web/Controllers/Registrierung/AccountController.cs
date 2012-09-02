using System.Web.Mvc;
using ApolloDb;

namespace Frontend.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly PraktikantRepository _praktikantRepository;

        public AccountController(PraktikantRepository praktikantRepository)
        {
            _praktikantRepository = praktikantRepository;
        }

        public ActionResult Registrierung()
        {
            return View(new RegistrierungModel());
        }

        [HttpPost]
        public ActionResult Registrierung(RegistrierungModel model)
        {
            if(!ModelState.IsValid)
            {
                model.Message = new ErrorMessage("Bitte korrigere Deine Daten");
                return View(model);
            }

            return View("RegistrierungErfolgreich", new RegistrierungErfolgreichModel());
        }

        public ActionResult RegistrierungErfolgreich()
        {
            return View(new RegistrierungErfolgreichModel());
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}