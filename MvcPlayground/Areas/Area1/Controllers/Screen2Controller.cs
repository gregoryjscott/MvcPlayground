﻿using System.Web.Mvc;
using RestMvc.Attributes;

namespace MvcPlayground.Areas.Area1.Controllers
{
    public class Screen2Controller : Controller
    {
        [Get("/Area1/Screen2")]
        public JsonResult Show()
        {
            return Json(new { content = "Screen 2" });
        }

        [Put("/Area1/Screen2")]
        public JsonResult Update()
        {
            return Json(new { success = true });
        }
    }
}
