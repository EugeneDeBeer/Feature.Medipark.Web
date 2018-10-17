using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.Domain;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Feature.OHS.Web.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffHandler _staffHandler;
        public StaffController(IStaffHandler staffHandler )
        {
            _staffHandler = staffHandler;
        }
        public IActionResult CreateDoctor()
        {

            return View("~/Views/Doctors/Create.cshtml",new StaffPayloadViewModel());
        }
        public IActionResult CreateNurse()
        {
            return View("~/Views/Nurses/Create.cshtml", new StaffPayloadViewModel());
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create(StaffPayloadViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _staffHandler.AddStaff(model);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Please enter all the required fields");
                return View(model);
            }
        }


        public IActionResult Index()
        {
            return View();
        }


    }
}