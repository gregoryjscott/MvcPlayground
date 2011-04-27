using System.Web.Mvc;
using MvcTemplate.Areas.Security.Models.AccountUpdates;
using RestMvc.Attributes;

namespace MvcTemplate.Areas.Security.Controllers
{
    public class AccountUpdatesController : Controller
    {
        [Post("/Security/AccountUpdates")]
        public ActionResult Create(AccountUpdate accountUpdate)
        {
            // TODO - persist it

            return Json(accountUpdate);
        }
    }
}
