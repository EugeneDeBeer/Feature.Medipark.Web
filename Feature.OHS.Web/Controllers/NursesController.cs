using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Feature.OHS.Web.Controllers
{
    public class NursesController : Controller
    {
        private readonly INurseHandler _nurseHandler;
        public NursesController(INurseHandler nurseHandler )
        {
            _nurseHandler = nurseHandler;
        } 

        public IActionResult Index()
        {
            var members = _nurseHandler.Nurses;
            return View("~/Views/Doctors/Index.cshtml", members);
      
        }
        public ActionResult Create()
        {
            return View("~/Views/Nurses/Create.cshtml", new DoctorNurseViewModel());
        }
        [HttpPost]
        public ActionResult CreateNurse(DoctorNurseViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.UserId = 1;
                    var result = _nurseHandler.AddNurse(model);
                   PersonId.Id = result.PersonId;
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
        [HttpPost]
        public ActionResult CreateContactAddress(DoctorNurseViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.PersonId = PersonId.Id;
                    var contact = _nurseHandler.AddContact(model);
                    var address = _nurseHandler.AddAddress(model);

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

    }
}