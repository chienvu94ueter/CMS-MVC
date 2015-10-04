using System;
using System.Linq;
using System.Web.Mvc;
using CPro.CommonCPro;
using ModelCPro.DataAccessLayer;
using ModelCPro.EntityFrameWork;
using PagedList;

namespace CPro.Areas.AdminCPro.Controllers
{
    public class UserController : BaseController
    {
        
        public ActionResult Index(string searchString,int page = 1, int pageSize = 3)
        {
            var dal = new UserDal();
            ViewBag.SearchString = searchString;
            var model = dal.GetAllUsers(searchString, page, pageSize);

            return View((IPagedList<User>)model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dal = new UserDal();
                var encryptor = Encryptor.MD5Hash(user.Password);
                user.Password = encryptor;

                long id = dal.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công");
                }
            }
            return View(user);
        }

        public ActionResult Edit(long id)
        {
            var user = new UserDal().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dal = new UserDal();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encryptor = Encryptor.MD5Hash(user.Password);
                    user.Password = encryptor;
                }

                var result = dal.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View(user);
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new UserDal().Delete(id);
            return RedirectToAction("Index");
        }

    }
}