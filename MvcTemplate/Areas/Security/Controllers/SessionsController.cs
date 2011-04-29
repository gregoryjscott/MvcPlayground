using System.Web.Mvc;
using MvcPlayground.Areas.Security.Models;
using MvcPlayground.Areas.Security.Models.Sessions;
using MvcPlayground.Areas.Security.Tasks.Sessions;
using MvcPlayground.Filters;
using Simpler;

namespace MvcPlayground.Areas.Security.Controllers
{
    [HandleAjaxException]
    public class SessionsController : Controller
    {
        [HttpPost]
        public ActionResult Create(SessionDetail sessionDetail)
        {
            if (ModelState.IsValid)
            {
                var createSession = TaskFactory<CreateSession>.Create();
                createSession.SessionDetail = sessionDetail;
                createSession.Execute();

                return Json(new { Success = true, User = sessionDetail.UserName });
            }

            return Json(new { Success = false });
        }

        [HttpPost]
        public ActionResult Delete()
        {
            var formsService = new FormsAuthenticationService();
            formsService.SignOut();

            return Json(new { Success = true });
        }
    }
}
