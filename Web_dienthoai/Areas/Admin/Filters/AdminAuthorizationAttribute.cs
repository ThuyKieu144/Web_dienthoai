using System.Web.Mvc;

namespace Web_dienthoai.Areas.Admin.Filters
{
    public class AdminAuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            var role = session["Role"]?.ToString();

            if (session["Username"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                        { "controller", "Account" },
                        { "action", "Index" },
                        { "area", "Admin" } // Specify the area if needed
                    });
            }
            else if (role == "User")
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                        { "controller", "Home" },
                        { "action", "Index" },
                        { "area", "" } // Specify no area to go to the main Home page
                    });
            }
            else if (role != "Admin")
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                        { "controller", "Account" },
                        { "action", "Index" },
                        { "area", "Admin" } // Specify the area if needed
                    });
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
