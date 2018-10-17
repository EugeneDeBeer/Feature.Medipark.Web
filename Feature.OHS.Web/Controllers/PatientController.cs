﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        public string GetPatients()
        {
            try
            {
                var patients = _patientHandler.GetPatients();                

                return patients;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View(new PatientPayloadViewModel());
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Create(PatientPayloadViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result =  _patientHandler.AddPatient(model);

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

        public ActionResult List()
        {
            return View();
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id, bool includeAllDetails = true)
        {
            try
            {
                var result = _patientHandler.GetPatient(id, includeAllDetails);

                if (result == null) return View();

                PatientPayloadViewModel patient = JsonConvert.DeserializeObject<PatientPayloadViewModel>(JsonConvert.SerializeObject(result));

                return View(patient);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Create));
            }

        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult Edit(/*int id, */ PatientPayloadViewModel model)
        {
            try
            {
               var result =  _patientHandler.UpdatePatient(model);

                if(result)
                    return RedirectToAction(nameof(Index));

                return View(model);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
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