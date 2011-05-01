using System.Web.Mvc;
using RestMvc.Attributes;

namespace MvcPlayground.Areas.Area1.Controllers
{
    public class Screen3Controller : Controller
    {
        [Get("/Area1/Screen3")]
        public JsonResult Show()
        {
            return Json(new { content = "Screen 3" });
        }

        [Put("/Area1/Screen3")]
        public JsonResult Update()
        {
            return Json(new { success = true });
        }
    }
}
