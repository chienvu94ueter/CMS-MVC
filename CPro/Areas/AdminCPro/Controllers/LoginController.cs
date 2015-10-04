using System.Web.Mvc;
using CPro.Areas.AdminCPro.Models;
using CPro.CommonCPro;
using ModelCPro.DataAccessLayer;

namespace CPro.Areas.AdminCPro.Controllers
{
    public class LoginController : Controller
    {
        // GET: AdminCPro/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dal = new UserDal();
                var result = dal.Login(model.UserName, Encryptor.MD5Hash(model.PassWord));
                if (result == 1)
                {
                    var user = dal.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserId = user.ID;
                    Session.Add(Constant.UserSession,userSession);
                    return RedirectToAction("Index","Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("","Tài khoản không tồn tại");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Tài khoản bị khóa");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi đăng nhập");
                }
            }
            return View("Index");
        }
    }
}