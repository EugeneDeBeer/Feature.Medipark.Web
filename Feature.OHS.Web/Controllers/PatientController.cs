using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Feature.OHS.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientHandler _patientHandler;

        public PatientController(IPatientHandler patientHandler)
        {
            _patientHandler = patientHandler;
        }

        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PayloadPatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    
                    var result = await _patientHandler.AddPatient(model);

                    return RedirectToAction(nameof(Create));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("Error","Please enter all the required fields");
                return View(model);
            }
        }

       // GET: Patient/Edit/5
        //public ActionResult Edit(int id)
        //{

        //    if (id == null) { return NotFound(); }
        //    var personVM = //create a get user function. 

        //    return View(person);
        //}

        // POST: Patient/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                // get the user

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Patient/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}