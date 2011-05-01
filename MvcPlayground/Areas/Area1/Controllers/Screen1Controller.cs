using System.Web.Mvc;
using RestMvc.Attributes;

namespace MvcPlayground.Areas.Area1.Controllers
{
    public class Screen1Controller : Controller
    {
        [Get("/Area1/Screen1")]
        public JsonResult Show()
        {
            return Json(new { content = "Screen 1" });
        }

        [Put("/Area1/Screen1")]
        public JsonResult Update()
        {
            return Json(new { success = true });
        }
    }
}
