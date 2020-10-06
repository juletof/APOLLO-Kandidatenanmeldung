using System;
using System.Linq;
using System.Text;
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

                var lines = _kandidatRepo.GetByIds(IndexAction.GetIds(model.CommandParams).ToArray())
                                         .Select(k => Kandidat2CsvLine.Run(k));
                if (lines.Count() > 0)
                    result += lines.Aggregate((a, b) => a + Environment.NewLine + b);
                else
                    result += "--- Sie haben keinen Kandidaten aus der Liste ausgewählt (Checkbox links neben dem Kandidaten). ---";

                return File(Encoding.UTF8.GetBytes(result), "text/csv", "KandiDaten.csv");
                
            }

            if (model.CommandName == "kandidatenEmailsExportieren")
            {
                var result = _kandidatRepo.GetByIds(IndexAction.GetIds(model.CommandParams).ToArray())
                    .Select(k => k.EmailAdresse)
                    .Aggregate((a, b) => a + Environment.NewLine + b);

                return File(Encoding.UTF8.GetBytes(result), "text/csv", "KandiMails.csv");
            }

            return View(Sl.Resolve<IndexAction>().Run(model));
        }

        [AuthorizedAdminOnly]
        public ActionResult Bilder()
        {
            KandidatBild.BilderZippen();

            return File(
                KandidatBild.ZipFileFullPath,
                "application/zip", KandidatBild.ZipFileName
            );
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

        [AuthorizedAdminOnly]
        [HttpPost]
        public void KandidatStatuswechsel(string neuerStatus, int kandidatId)
        {
            if(neuerStatus == "auswahl1")
                Sl.Resolve<ZurAuswahl1>().Run(kandidatId);

            if (neuerStatus == "auswahl2")
                Sl.Resolve<ZurAuswahl2>().Run(kandidatId);

            if (neuerStatus == "reserve")
                Sl.Resolve<ZurReserve>().Run(kandidatId);
        }
    }
}