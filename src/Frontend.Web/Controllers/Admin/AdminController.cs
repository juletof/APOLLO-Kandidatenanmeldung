using System;
using System.Linq;
using System.Web.Mvc;
using ApolloDb;

namespace Frontend.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly SessionUser _sessionUser;
        private readonly KandidatRepository _kandidatRepo;

        public AdminController(SessionUser sessionUser, KandidatRepository kandidatRepo)
        {
            _sessionUser = sessionUser;
            _kandidatRepo = kandidatRepo;
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
            if (model.CommandName == "kandidatenExportieren")
            {
                var result = Kandidat2CsvLine.RunFirstLine() + Environment.NewLine;
                result += _kandidatRepo.GetByIds(IndexAction.GetIds(model.CommandParams).ToArray())
                                       .Select(Kandidat2CsvLine.Run)
                                       .Aggregate((a, b) => a + Environment.NewLine + b);

                return new ContentResult
                {
                    Content  = result,
                    ContentType = "text/csv"
                };                
            }

            if (model.CommandName == "kandidatenEmailsExportieren")
            {
                return new ContentResult
                {
                    Content = _kandidatRepo.GetByIds(IndexAction.GetIds(model.CommandParams).ToArray())
                                           .Select(k => k.EmailAdresse)
                                           .Aggregate((a, b) => a + Environment.NewLine + b),
                    ContentType = "text/csv"
                };                
            }

            return View(Sl.Resolve<IndexAction>().Run(model));
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

        [AuthorizedAdminOnly][HttpPost]
        public void KandidatLoeschen(int id){
            Sl.Resolve<KandidatLoeschen>().Run(id);
        }

        [AuthorizedAdminOnly][HttpPost]
        public void KandidatAusschliessen(int id){
            Sl.Resolve<KandidatAusschliessen>().Run(id);
        }

        [AuthorizedAdminOnly][HttpPost]
        public void KandidatZulassen(int id){
            Sl.Resolve<KandidatZulassen>().Run(id);
        }
    }
}