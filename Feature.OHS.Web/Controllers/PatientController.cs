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
  
 
        public ActionResult Create()
        {
            return View(new PatientPayloadViewModel());
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult CreatePatient(PatientPayloadViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.UserId = 1;
                    var result =  _patientHandler.AddPatient(model);
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
                ModelState.AddModelError("Error","Please enter all the required fields");
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult CreateContact(PatientPayloadViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.PersonId = PersonId.Id;
                    var result = _patientHandler.AddContact(model);
                    var address = _patientHandler.AddAddress(model);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex ) 
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
    

        public ActionResult List()
        {
            return View();
        }

        // GET: Patient/Edit/5
        

        public IActionResult Patients()
        {
            var patient = _patientHandler.Patients;
            return View("~/Views/Patient/Index.cshtml", patient);
        }

        [HttpPost]
        public ActionResult EditPatient(PatientPayloadViewModel patientViewModel)
        {
             var result = _patientHandler.UpdatePatient(patientViewModel);
                return RedirectToAction(nameof(Index));
           
              
        }

        public IActionResult EditPatient(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = _patientHandler.GetPatientByIdNumber(id);
          //  var _nokVM = new NextOfKinViewModel();
           // var tupleData = new Tuple<PatientViewModel, NextOfKinViewModel>(user, _nokVM);
          
            if (user == null)
            {
                return NotFound();
            }
            return View("~/Views/Patient/Edit.cshtml", user);
        }

        public IActionResult Edit()
        {
          
            return View("~/Views/Patient/Edit.cshtml");
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