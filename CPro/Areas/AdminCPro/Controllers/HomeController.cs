using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPro.Areas.AdminCPro.Controllers
{
    public class HomeController : BaseController
    {
        // GET: AdminCPro/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}