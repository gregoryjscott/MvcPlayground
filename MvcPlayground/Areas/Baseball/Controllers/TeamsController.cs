using System.Web.Mvc;
using MvcPlayground.Models;
using RestMvc.Attributes;

namespace MvcPlayground.Areas.Baseball.Controllers
{
    [Screen]
    public class TeamNamesController : Controller
    {
        [Get("/TeamNames")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
