using System.Web.Mvc;
using ApolloDb;

namespace Frontend.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly PraktikantRepository _praktikantRepo;

        public AdminController(PraktikantRepository praktikantRepo){
            _praktikantRepo = praktikantRepo;
        }

        public ActionResult Index()
        {
            
            return View(new PraktikantenModel(_praktikantRepo.GetAll()));
        }
    }
}
