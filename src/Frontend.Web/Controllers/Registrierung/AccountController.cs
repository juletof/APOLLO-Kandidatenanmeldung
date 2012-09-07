using System.Web.Mvc;
using ApolloDb;

namespace Frontend.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly Registrieren _registrieren;

        public AccountController(Registrieren registrieren){
            _registrieren = registrieren;
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

            _registrieren.Run(RegistrierungModel2Entity.Run(model));

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

        public ActionResult Dashboard()
        {
            return View();
        }
    }
}