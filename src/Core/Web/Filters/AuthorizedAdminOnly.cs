using System.Web.Mvc;

namespace ApolloDb
{
    public class AuthorizedAdminOnly : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionUser = Sl.Resolve<SessionUser>();
            if (!sessionUser.IsLoggedInAdmin)
                filterContext.Result = new RedirectResult("/Admin/Login");

            base.OnActionExecuting(filterContext);
        }
    }
}
