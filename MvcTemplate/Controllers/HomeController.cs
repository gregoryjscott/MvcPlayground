using System.Web.Mvc;
using RestMvc.Attributes;

namespace MvcTemplate.Controllers
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
