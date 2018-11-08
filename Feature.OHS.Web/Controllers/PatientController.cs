﻿using System;
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

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View(new PatientViewModel());
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult CreatePatient(PatientViewModel model)
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
        public ActionResult CreateContact(PatientViewModel model)
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
        public ActionResult Edit(int id, bool includeAllDetails = true)
        {
            try
            {
                var patient = _patientHandler.GetPatient(id, includeAllDetails);

                if (patient == null) return View();

                return View(patient);

                //if(patient == null) return RedirectToAction(nameof(Create));

                //return View("Create", patient);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Create));
            }

        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PatientViewModel model)
        {
            try
            {
             //  var result =  _patientHandler.UpdatePatient(model);

                //if(result)
                //    return RedirectToAction(nameof(Create));

                return View(model);
            }
            catch
            {
                return RedirectToAction(nameof(Create));
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