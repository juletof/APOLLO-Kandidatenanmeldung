using System;
using System.Web.Mvc;
using ApolloDb;
using ApolloDb.Infrastructure;

namespace Frontend.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly KandidatRepository _kandidatRepo;
        private readonly SessionUser _sessionUser;

        public AdminController(KandidatRepository kandidatRepo, SessionUser sessionUser)
        {
            _kandidatRepo = kandidatRepo;
            _sessionUser = sessionUser;
        }

        public ActionResult Login()
        {
            return View(new LoginModelAdmin());
        }

        [HttpPost]
        public ActionResult Login(LoginModelAdmin loginModelAdmin)
        {

            if (Sl.Resolve<SindAdminZugangsdatenGueltig>().Ja(loginModelAdmin.Nutzername, loginModelAdmin.Password))
            {
                _sessionUser.LoginAsAdmin();
                return new RedirectResult("/Admin/");
            }

            loginModelAdmin.Message = new ErrorMessage("Zugangsdaten nicht korrekt.");
            return View(loginModelAdmin);
        }


        [AuthorizedAdminOnly]
        [HttpPost]
        public ActionResult Index(KandidatenModel model)
        {
            var searchSpec = new KandidatSearchSpec();

            if (model.FilterZugelassen) searchSpec.Filter.Stati.Add(KandidatStatus.Zugelassen);
            if (model.FilterRegistriert) searchSpec.Filter.Stati.Add(KandidatStatus.Registriert);
            if (model.FilterDatenVollständig) searchSpec.Filter.Stati.Add(KandidatStatus.AnmeldungVollstaendig);
            searchSpec.Filter.Stati.Add(KandidatStatus.NichtDefiniert);

            if (model.FilterUniVal == null || model.FilterUniVal == "-1")
                searchSpec.Filter.Uni.Reset();
            else
                searchSpec.Filter.Uni.EqualTo(model.FilterUniVal);

            if (String.IsNullOrEmpty(model.FilterFreiText))
                searchSpec.Filter.TextSearch.Clear();
            else
                searchSpec.Filter.TextSearch.AddTerms(model.FilterFreiText);
            
            model.SetKandidaten(
                _kandidatRepo.GetBy(searchSpec),
                Sl.Resolve<StatusStatistikLaden>().Run(Convert.ToInt32(model.FilterUniVal))
            );
            return View(model);
        }

        [AuthorizedAdminOnly]
        public ActionResult ResetFilter(){
            return RedirectToAction("Index");
        }

        [AuthorizedAdminOnly]
        public ActionResult Index()
        {
            var kandidatenModel = new KandidatenModel();
            kandidatenModel.FilterZugelassen = true;
            kandidatenModel.FilterRegistriert = true;
            kandidatenModel.FilterDatenVollständig = true;

            return Index(kandidatenModel);
        }

        [HttpPost]
        public void KandidatLoeschen(int id)
        {
            Sl.Resolve<KandidatLoeschen>().Run(id);
        }
    }
}