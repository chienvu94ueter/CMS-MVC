using System.Web.Mvc;
using ModelCPro.DataAccessLayer;

namespace CPro.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            // lay ra Menu co TypeID la 1 (Menu chinh)
            var model = new MenuDal().GetAllMenus(2);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            // lay ra Menu co TypeID la 1 (Menu chinh)
            var model = new MenuDal().GetAllMenus(1);
            return PartialView(model);
        }
    }
}