using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VJP_App.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string st = (string)RouteData.Values["controller"];
            string cn = (string)Session["userTypeName"];
            if (Session["email"] == null || (string)Session["userTypeName"] != (string)RouteData.Values["controller"])
            {
                //Response.Redirect("/Login");
                filterContext.Result = new RedirectToRouteResult
                (
                    new RouteValueDictionary
                    {
                        {"controller","Login"},{"action","Index"}
                    }
                );
            }
        }
    }
}
