using System.Web;
using System.Web.Mvc;

namespace ApolloDb
{
    public class AuthorizedKandidatOnly : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionUser = Sl.Resolve<SessionUser>();
            if (!sessionUser.IsLoggedInKandidat)
                filterContext.Result = new RedirectResult("/Account/LogOff");

            base.OnActionExecuting(filterContext);
        }
    }
}
