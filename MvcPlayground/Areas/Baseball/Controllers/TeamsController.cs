﻿using System.Linq;
using System.Web.Mvc;
using MvcPlayground.Areas.Baseball.Models;
using MvcPlayground.Models;
using RestMvc.Attributes;

namespace MvcPlayground.Areas.Baseball.Controllers
{
    [Screen]
    public class TeamsController : Controller
    {
        [Get("/Teams/{id}")]
        public JsonResult Show(string id)
        {
            return Json(Mlb.Teams.Where(team => team.Name == id));
        }
    }
}
