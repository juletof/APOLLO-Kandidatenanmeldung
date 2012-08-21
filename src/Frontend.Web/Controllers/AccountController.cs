using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Frontend.Web.Models;

namespace Frontend.Web.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Registrierung()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

       
    }
}
