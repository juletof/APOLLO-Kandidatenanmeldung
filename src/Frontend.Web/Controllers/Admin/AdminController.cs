using System.Web.Mvc;
using ApolloDb;

namespace Frontend.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly KandidatRepository _kandidatRepo;

        public AdminController(KandidatRepository kandidatRepo){
            _kandidatRepo = kandidatRepo;
        }

        public ActionResult Index()
        {
            return View(new PraktikantenModel(_kandidatRepo.GetAll()));
        }
    }
}
