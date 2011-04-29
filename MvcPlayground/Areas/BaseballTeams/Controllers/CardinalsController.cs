using System.Web.Mvc;
using MvcPlayground.Areas.BaseballTeams.Models;
using MvcPlayground.Models;
using RestMvc.Attributes;

namespace MvcPlayground.Areas.BaseballTeams.Controllers
{
    [Screen]
    public class CardinalsController : Controller
    {
        [Get("/Cardinals")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
