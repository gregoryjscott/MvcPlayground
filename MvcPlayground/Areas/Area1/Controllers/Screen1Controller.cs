using System.Web.Mvc;
using RestMvc.Attributes;

namespace MvcPlayground.Areas.Area1.Controllers
{
    public class Screen1Controller : Controller
    {
        [Get("/Area1/Screen1")]
        public JsonResult Show()
        {
            return Json(new { Content = "Screen 1"});
        }
    }
}
