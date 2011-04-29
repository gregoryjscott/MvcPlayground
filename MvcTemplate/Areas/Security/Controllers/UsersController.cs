using System.Web.Mvc;
using MvcPlayground.Filters;

namespace MvcPlayground.Areas.Security.Controllers
{
    [AjaxAuthorize]
    [HandleAjaxException]
    public class UsersController : Controller
    {
        //[HttpPost]
        //public ActionResult Create(UserDetail userDetail)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var createUser = TaskFactory<CreateUser>.Create();
        //        createUser.UserDetail = userDetail;
        //        createUser.Execute();

        //        if (createUser.MembershipCreateStatus == MembershipCreateStatus.Success)
        //        {
        //            return Json(new { Success = true });
        //        }
        //    }

        //    return Json(new { Success = false });
        //}

        //[HttpPost]
        //public ActionResult Update(ChangePasswordModel changePasswordModel)
        //{
        //    return Json(changePasswordModel);
        //}
    }
}
