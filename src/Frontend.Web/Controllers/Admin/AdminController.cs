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

        public ActionResult Login() { return View(new LoginModelAdmin()); }

        [HttpPost]
        public ActionResult Login(LoginModelAdmin loginModelAdmin)
        {

            if(Sl.Resolve<SindAdminZugangsdatenGueltig>().Ja(loginModelAdmin.Nutzername, loginModelAdmin.Password))
            {
                _sessionUser.LoginAsAdmin();
                return new RedirectResult("/Admin/");
            }

            loginModelAdmin.Message = new ErrorMessage("Zugangsdaten nicht korrekt.");
            return View(loginModelAdmin);
        }


        [AuthorizedAdminOnly]
        public ActionResult Index()
        {
            return View(new PraktikantenModel(_kandidatRepo.GetAll()));
        }
    }
}