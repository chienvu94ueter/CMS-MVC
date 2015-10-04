using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPro.Areas.AdminCPro.Controllers
{
    public class NewsController : BaseController
    {
        // GET: AdminCPro/News
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}