﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Feature.OHS.Web.Controllers
{
    public class NursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}