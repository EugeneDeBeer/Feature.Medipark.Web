using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Feature.OHS.Web.Controllers
{
    public class AdmissionsController : Controller
    {
        private readonly IPatientHandler _patientHandler;

        public AdmissionsController(IPatientHandler patientHandler)
        {
            _patientHandler = patientHandler;
        }

        public IActionResult Index()
        {
            //var patients = _patientHandler.GetPatients();            
            var patients = _patientHandler.Patients;

            return View(patients);
        }

        //public IActionResult Create(int personId)
        //{
        //    var patient = _patientHandler.GetPatientByPersonId(personId);

        //    if (patient == null)
        //    {
        //        //ModelState.AddModelError("Search Service", "Our search service is currently down. Try again later!");
        //        return View("Error", new ErrorViewModel(){ RequestId = StatusCode((int)HttpStatusCode.NotFound).ToString() });
        //    }

        //    var admissionViewModel = MapperHelper.Map<AdmissionViewModel, PatientPayloadViewModel>(new AdmissionViewModel(), patient);
        //    return View(admissionViewModel);
        //}

        public IActionResult Create(string idNumber)
        {
            if (string.IsNullOrWhiteSpace(idNumber))
                return View("Error", new ErrorViewModel() { RequestId = "Patient ID number submitted is empty" });

            var patient = _patientHandler.GetPatientByIdNumber(idNumber);

            if (patient == null)
            {
                //ModelState.AddModelError("Search Service", "Our search service is currently down. Try again later!");
                return View("Error", new ErrorViewModel() { RequestId = StatusCode((int)HttpStatusCode.NotFound).ToString() });
            }

            var admissionViewModel = MapperHelper.Map<AdmissionViewModel, PatientPayloadViewModel>(new AdmissionViewModel(), patient);
            return View(admissionViewModel);
        }

        [HttpPost]
        public IActionResult Create(AdmissionViewModel model)
        {
            //return View();
            return RedirectToAction(nameof(Index));
        }
    }
}