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
        private readonly IStaffHandler _staffHandler;
        public StaffController(IStaffHandler staffHandler)
        {
            _staffHandler = staffHandler;
        }

        public IActionResult Create()
        {
            return View(new StaffPayloadViewModel());
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}