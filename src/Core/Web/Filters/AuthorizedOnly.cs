using System.Web;
using System.Web.Mvc;

namespace ApolloDb
{
    public class AuthorizedOnly : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionUser = Sl.Resolve<SessionUser>();
            if (!sessionUser.IsLoggedIn)
                filterContext.Result = new RedirectResult("/Account/LogOff");

            base.OnActionExecuting(filterContext);
        }
    }
}
