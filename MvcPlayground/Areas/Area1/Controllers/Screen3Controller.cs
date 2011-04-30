﻿using System.Web.Mvc;
using RestMvc.Attributes;

namespace MvcPlayground.Areas.Area1.Controllers
{
    public class Screen3Controller : Controller
    {
        [Get("/Area1/Screen3")]
        public JsonResult Show()
        {
            return Json(new { Content = "Screen 3" });
        }
    }
}