using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Feature.OHS.Web.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Create()
        {
            return View("~/Views/Nurses/Create.cshtml",new StaffPayloadViewModel());
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}