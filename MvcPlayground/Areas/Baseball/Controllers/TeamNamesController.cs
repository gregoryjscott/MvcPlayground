using System.Web.Mvc;
using MvcPlayground.Areas.Baseball.Models;
using MvcPlayground.Models;
using RestMvc.Attributes;
using System.Linq;

namespace MvcPlayground.Areas.Baseball.Controllers
{
    [Screen]
    public class TeamNamesController : Controller
    {
        [Get("/TeamNames")]
        public JsonResult Index()
        {
            return Json(Mlb.Teams.Select(team => team.Name));
        }
    }
}
