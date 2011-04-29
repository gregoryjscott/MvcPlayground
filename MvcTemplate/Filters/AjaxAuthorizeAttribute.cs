using System.Web.Mvc;
using MvcPlayground.Results;

namespace MvcPlayground.Filters
{
    public class AjaxAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpForbiddenResult();
        }
    }
}