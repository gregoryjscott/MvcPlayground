using System.Web.Mvc;
using RestMvc.Attributes;

namespace MvcPlayground.Areas.BaseballTeams.Controllers
{
    public class CardinalsController : Controller
    {
        [Get("/Cardinals")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
