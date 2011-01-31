using System.Web.Mvc;
using System.Web.Security;
using MvcTemplate.Models;

namespace MvcTemplate.Areas.Security.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Create(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var membershipService = new AccountMembershipService();
                MembershipCreateStatus createStatus = membershipService.CreateUser(model.UserName, model.Password, model.Email);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    return Json(new { Success = true });
                }
            }

            return Json(new { Success = false });
        }
    }
}
