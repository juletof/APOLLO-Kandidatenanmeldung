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
        public ActionResult Index(KandidatenModel kandidatenModel)
        {
            var searchSpec = new KandidatSearchSpec();

            if (kandidatenModel.FilterZugelassen) searchSpec.Filter.Stati.Add(KandidatStatus.Zugelassen);
            if (kandidatenModel.FilterRegistriert) searchSpec.Filter.Stati.Add(KandidatStatus.Registriert);
            if (kandidatenModel.FilterDatenVollständig) searchSpec.Filter.Stati.Add(KandidatStatus.AnmeldungVollstaendig);
            searchSpec.Filter.Stati.Add(KandidatStatus.NichtDefiniert);

            kandidatenModel.SetKandidaten(_kandidatRepo.GetBy(searchSpec));
            return View(kandidatenModel);
        }

        [AuthorizedAdminOnly]
        public ActionResult Index()
        {
            var kandidatenModel = new KandidatenModel(_kandidatRepo.GetAll());
            kandidatenModel.FilterZugelassen = true;
            kandidatenModel.FilterRegistriert = true;
            kandidatenModel.FilterDatenVollständig = true;

            return View(kandidatenModel);
        }

        [HttpPost]
        public void KandidatLoeschen(int id)
        {
            Sl.Resolve<KandidatLoeschen>().Run(id);
        }
    }
}