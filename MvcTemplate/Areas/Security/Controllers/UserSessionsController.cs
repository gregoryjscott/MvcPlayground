using System.Web.Mvc;
using MvcTemplate.Models;

namespace MvcTemplate.Areas.Security.Controllers
{
    public class UserSessionsController : Controller
    {
        [HttpPost]
        public ActionResult Create(LogOnModel logOnModel)
        {
            var membershipService = new AccountMembershipService();
            if (ModelState.IsValid && membershipService.ValidateUser(logOnModel.UserName, logOnModel.Password))
            {
                var formsService = new FormsAuthenticationService();
                formsService.SignIn(logOnModel.UserName, false);

                return Json(new { Success = true, User = logOnModel.UserName });
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
