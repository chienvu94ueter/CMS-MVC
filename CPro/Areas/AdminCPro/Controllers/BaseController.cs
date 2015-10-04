using System.Web.Mvc;
using System.Web.Routing;
using CPro.CommonCPro;

namespace CPro.Areas.AdminCPro.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin) Session[Constant.UserSession];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new
                    {
                        controller ="Login",
                        action = "Index",
                        Area ="AdminCPro"
                    }    
                ));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}