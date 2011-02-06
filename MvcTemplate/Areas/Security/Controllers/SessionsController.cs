using System.Web.Mvc;
using MvcTemplate.Areas.Security.Models;
using MvcTemplate.Areas.Security.Models.Sessions;
using MvcTemplate.Areas.Security.Tasks.Sessions;
using MvcTemplate.Models;
using Simpler;

namespace MvcTemplate.Areas.Security.Controllers
{
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
            //var membershipService = new AccountMembershipService();
            //if (ModelState.IsValid && membershipService.ValidateUser(sessionDetail.UserName, sessionDetail.Password))
            //{
            //    var formsService = new FormsAuthenticationService();
            //    formsService.SignIn(sessionDetail.UserName, false);

            //    return Json(new { Success = true, User = sessionDetail.UserName });
            //}

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
