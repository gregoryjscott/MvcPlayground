using System.Web.Mvc;
using MvcTemplate.Areas.Security.Models.Sessions;
using MvcTemplate.Models;

namespace MvcTemplate.Areas.Security.Controllers
{
    public class SessionsController : Controller
    {
        [HttpPost]
        public ActionResult Create(SessionDetail sessionDetail)
        {
            var membershipService = new AccountMembershipService();
            if (ModelState.IsValid && membershipService.ValidateUser(sessionDetail.UserName, sessionDetail.Password))
            {
                var formsService = new FormsAuthenticationService();
                formsService.SignIn(sessionDetail.UserName, false);

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
