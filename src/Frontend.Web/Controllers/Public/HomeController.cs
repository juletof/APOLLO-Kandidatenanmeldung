using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Information_Praktikum()
        {
            return View();
        }
    }
}
