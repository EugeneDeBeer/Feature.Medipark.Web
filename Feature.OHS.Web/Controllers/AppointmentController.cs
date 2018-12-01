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
     
        [HttpPost("Appointment")]
        public ActionResult Create(AppointmentViewModel appointmentViewModel)
        {
            _appointmentHandler.Create(appointmentViewModel);
            return RedirectToAction(nameof(Index));
        }
       
        [HttpPost("Update")]
        public ActionResult UpdateAppointment(AppointmentViewModel appointmentViewModel)
        {
            _appointmentHandler.Update(appointmentViewModel);
            return RedirectToAction(nameof(Index));
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

        public ActionResult CancelAppointment(AppointmentViewModel model)
        {
            if( model == null)
                {
                    ViewBag.Error = "Ooops something went wrong please try again";
                    return View("Index");
                }

                var result = _appointmentHandler.CancelAppointment(model);
                return View("Index", result);
           
        }
    }
}