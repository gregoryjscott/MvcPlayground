using System.Web.Mvc;
using System.Web.Security;
using MvcTemplate.Areas.Security.Models.Users;
using MvcTemplate.Areas.Security.Tasks.Users;
using Simpler;

namespace MvcTemplate.Areas.Security.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Create(UserDetail userDetail)
        {
            if (ModelState.IsValid)
            {
                var createUser = TaskFactory<CreateUser>.Create();
                createUser.UserDetail = userDetail;
                createUser.Execute();

                if (createUser.MembershipCreateStatus == MembershipCreateStatus.Success)
                {
                    return Json(new { Success = true });
                }
            }

            return Json(new { Success = false });
        }
    }
}
