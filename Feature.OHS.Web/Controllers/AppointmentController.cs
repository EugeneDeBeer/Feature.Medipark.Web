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
    public class AppointmentController : Controller
    {
        private readonly IAppointmentHandler _appointmentHandler;
        public AppointmentController(IAppointmentHandler appointmentHandler)
        {
            _appointmentHandler = appointmentHandler;
        }
        // GET: DoctorsAppointment
        public ActionResult Index(AppointmentViewModel model)
        {
            if(model == null)
                return View(new AppointmentViewModel());

            return View(model);
        }
        public ActionResult PopulatedIndex(AppointmentViewModel appointmentViewModel )
        {
            return View("~/Views/Appointment/PopulatedIndex.cshtml",appointmentViewModel);
        }

        [HttpPost("Appointment")]
        public ActionResult Create(AppointmentViewModel appointmentViewModel)
        {
            _appointmentHandler.Create(appointmentViewModel);
            return   RedirectToAction(nameof(Index));
        }
       
        public ActionResult GetAppointment(string id)
        {
             var appointment =_appointmentHandler.GetAppointmentByIdNumber(id);
            return RedirectToAction(nameof(Index), appointment);
        }

        public JsonResult GetAppointments() {
            var appointments = _appointmentHandler.GetAppointments;
            return new JsonResult(appointments);
        }

    }
}