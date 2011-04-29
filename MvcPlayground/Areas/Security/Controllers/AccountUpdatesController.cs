using System.Web.Mvc;
using MvcPlayground.Areas.Security.Models;
using MvcPlayground.Areas.Security.Models.AccountUpdates;
using RestMvc.Attributes;

namespace MvcPlayground.Areas.Security.Controllers
{
    public class AccountUpdatesController : Controller
    {
        [Post("/Security/AccountUpdates")]
        public ActionResult Create(AccountUpdate accountUpdate)
        {
            if (ModelState.IsValid)
            {
                var membershipService = new AccountMembershipService();
                if (membershipService.ChangePassword(User.Identity.Name, accountUpdate.OldPassword, accountUpdate.NewPassword))
                {
                    return Json(new { Success = true });
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            return Json(accountUpdate);
        }
    }
}
