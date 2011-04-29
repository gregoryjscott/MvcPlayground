using System.Web.Mvc;
using MvcPlayground.Areas.Baseball.Models;
using MvcPlayground.Models;
using RestMvc.Attributes;

namespace MvcPlayground.Areas.Baseball.Controllers
{
    [Screen]
    public class TeamsController : Controller
    {
        [Get("/Teams/{id}")]
        public ActionResult Show(TeamName id)
        {
            return View();
        }
    }
}
