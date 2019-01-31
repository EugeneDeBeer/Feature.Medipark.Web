using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Feature.OHS.Web.Controllers
{
    public class SurveyController : Controller
    {
        public IActionResult Satisfaction()
        {
            return View();
        }
    }
}