using System;
using System.Web;
using System.Web.Mvc;

namespace ApolloDb
{
    public class AuthorizedOnly : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionUser = new SessionUser();
            if (!sessionUser.IsLoggedIn)
                HttpContext.Current.Response.Redirect("/Account/LogOff", true);

            base.OnActionExecuting(filterContext);
        }
    }
}
