using System;
using System.Web.Mvc;

namespace MvcPlayground.Results
{
    public class HttpForbiddenResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            context.HttpContext.Response.StatusCode = 403;
        }
    }
}
