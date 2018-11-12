using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Feature.OHS.Web.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorHandler _doctorHandler;
        public DoctorsController(IDoctorHandler doctorHandler)
        {
            _doctorHandler = doctorHandler;
        }

        public ActionResult Create()
        {
            return View("~/Views/Doctors/Create.cshtml", new DoctorNurseViewModel());
        }


        [HttpPost]
        public ActionResult CreateDoctor(DoctorNurseViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.UserId = 1;
                    var result = _doctorHandler.AddDoctor(model);
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
                    var contact = _doctorHandler.AddContact(model);
                    var address = _doctorHandler.AddAddress(model);
                    
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
        public IActionResult EditDoctor(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _doctorHandler.Doctors;
            if (user == null)
            {
                return NotFound();
            }
            return View("~/Views/Doctors/Edit.cshtml", user);
        }
        public IActionResult Doctors()
        {
            var members = _doctorHandler.Doctors;
            return View("~/Views/Doctors/Index.cshtml", members);
        }
        [HttpPost]
        public ActionResult PracticeInfo(DoctorNurseViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.PersonId = PersonId.Id;
                    var practiceInfo = _doctorHandler.AddPracticeInformation(model);

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
        public ActionResult CreateQualification(DoctorNurseViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.PersonId = PersonId.Id;
                    var practiceInfo = _doctorHandler.AddQualification(model);
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
        // GET: Doctors
        public ActionResult Index()
        {
            return View();
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Doctors/Create
        

        // POST: Doctors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        
    }
}