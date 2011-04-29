using System.Web.Mvc;
using MvcPlayground.Areas.Baseball.Models;
using RestMvc.Attributes;
using System.Linq;

namespace MvcPlayground.Areas.Baseball.Controllers
{
    public class TeamNamesController : Controller
    {
        [Get("/TeamNames")]
        public JsonResult Index()
        {
            return Json(Mlb.Teams.Select(team => team.Name));
        }
    }
}
