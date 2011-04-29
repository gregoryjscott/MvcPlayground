using System.Web.Mvc;
using RestMvc.Attributes;
using System.Linq;

namespace MvcPlayground.Controllers
{
    public class AreasController : Controller
    {
        [Get("/Areas/{id}")]
        public JsonResult Show(string id)
        {
            return Json(Models.Areas.All.Where(m => m.Id == id));
        }
    }
}
