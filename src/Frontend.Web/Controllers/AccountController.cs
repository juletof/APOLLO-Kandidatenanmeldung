using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Frontend.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Registrierung()
        {
            return View(new RegistrierungModel());
        }

        [HttpPost]
        public ActionResult Registrierung(RegistrierungModel model)
        {
            model.VornameKY = "adsjflkasjödfl";
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}
