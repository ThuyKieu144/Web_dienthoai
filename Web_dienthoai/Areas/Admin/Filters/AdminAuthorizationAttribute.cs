using System.Web.Mvc;

namespace Web_dienthoai.Areas.Admin.Filters
{
    public class AdminAuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            if (session["Username"] == null || session["Role"]?.ToString() != "Admin")
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
