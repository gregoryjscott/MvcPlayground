using System.Linq;
using System.Web.Mvc;
using MvcPlayground.Areas.Baseball.Models;
using RestMvc.Attributes;

namespace MvcPlayground.Areas.Baseball.Controllers
{
    public class TeamsController : Controller
    {
        [Get("/Teams")]
        public JsonResult Index()
        {
            return Json(Mlb.Teams);
        }

        [Get("/Teams/{id}")]
        public JsonResult Show(string id)
        {
            return Json(Mlb.Teams.Where(team => team.Name == id));
        }
    }
}
