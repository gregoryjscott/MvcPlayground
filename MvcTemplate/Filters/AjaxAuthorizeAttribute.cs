using System.Web.Mvc;
using MvcTemplate.Results;

namespace MvcTemplate.Filters
{
    public class AjaxAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpForbiddenResult();
        }
    }
}