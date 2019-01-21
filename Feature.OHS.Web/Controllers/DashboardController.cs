using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.Helper;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Feature.OHS.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IPatientHandler _patientHandler;

        public DashboardController(IPatientHandler patientHandler)
        {
            _patientHandler = patientHandler;
        }

        public IActionResult Dashboard()
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("User")))
            {
                return RedirectToAction("Login", nameof(Account), new { returnUrl = Url.Action(nameof(DashboardController.Dashboard), nameof(Dashboard)) });
            }

            var user = HttpContext.Session.GetObject<PersonViewModel>("User");

            if (user == null)
                return RedirectToAction("Login", nameof(Account), new { returnUrl = Url.Action(nameof(DashboardController.Dashboard), nameof(Dashboard)) });


            var patients = _patientHandler.InPatientsList();

            if(patients == null)
                return View();

            return View(patients);
        }
        

    }
}