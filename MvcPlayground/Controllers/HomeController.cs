using System.Web.Mvc;

namespace MvcPlayground.Controllers
{
    public class HomeController : Controller
    {
//        [Get("/")]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }
    }
}
