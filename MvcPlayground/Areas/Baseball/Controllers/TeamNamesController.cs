using System.Web.Mvc;
using MvcPlayground.Areas.Baseball.Models;
using MvcPlayground.Models;
using RestMvc.Attributes;
using System.Linq;

namespace MvcPlayground.Areas.Baseball.Controllers
{
    [Screen]
    public class TeamsController : Controller
    {
        [Get("/Teams/{id}")]
        public JsonResult Show(string id)
        {
            return Json(Mlb.Teams.Select(team => team.Name == id));
        }
    }
}
