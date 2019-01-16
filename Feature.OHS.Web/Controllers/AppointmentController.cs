using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Feature.OHS.Web.Helper;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Feature.OHS.Web.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentHandler _appointmentHandler;
        private readonly IDoctorHandler _doctorHandler;
        public AppointmentController(IAppointmentHandler appointmentHandler, IDoctorHandler doctorHandler)
        {
            _appointmentHandler = appointmentHandler;
            _doctorHandler = doctorHandler;

        }

        // GET: DoctorsAppointment
        //public ActionResult Index()
        //{
        //    if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("User")))
        //    {
        //        return RedirectToAction("Login", nameof(Account), new { returnUrl = Url.Action(nameof(AppointmentController.Index), "Appointment") });
        //    }

        //    return View(new AppointmentViewModel());
        //}

        // GET: DoctorsAppointment
        public ActionResult Index(AppointmentViewModel model)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("User")))
            {
                return RedirectToAction("Login", nameof(Account), new { returnUrl = Url.Action(nameof(AppointmentController.Index), "Appointment") });
            }

            return View(model.AppointmentId > 0 ? model : new AppointmentViewModel());

            //var user = HttpContext.Session.GetObject<PersonViewModel>("User");
            //if (user == null)
            //    return RedirectToAction("Login", nameof(Account), new { returnUrl = Url.Action(nameof(AppointmentController.Index), "Appointment") });
            //if (user.UserRoleId == 3)
            //{
            //    //return RedirectToAction("Index", "Appointment", response);
            //    return View("Index", model.AppointmentId > 0 ? model : new AppointmentViewModel());
            //}
            //else if (user.UserRoleId == 2)
            //{
            //    return View("Index", model.AppointmentId > 0 ? model : new AppointmentViewModel());
            //}
            //else
            //{
            //    return RedirectToAction("Dashboard", "Dashboard");
            //}
        }

        public ActionResult SearchPatient(AppointmentViewModel model)
        {
            if (model == null)
                return View(new AppointmentViewModel());

            return View(model);
        }

        //public ActionResult SearchAppointment(AppointmentViewModel model)
        //{
        //    var appointments = _appointmentHandler.GetAppointments;
        //    ViewBag.appointmentList = appointments;
        //    //if (model == null)
        //    //    return View(new AppointmentViewModel(),appointments);

        //    return View(appointments);
        //}
        public ActionResult SearchAppointment(string id)
        {
            try
            {
                if (id == null)
                {

                    ViewBag.ErrorMessage = "Please Enter a valid ID Number";
                    return View("Index");
                }

                var appointment = _appointmentHandler.GetAppointmentsByIdNumber(id);
                ViewBag.appointmentList = appointment;
                return View("Index", new AppointmentViewModel());
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("Index");
            }
        }

        public ActionResult Theatre(AppointmentViewModel model)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("User")))
            {
                return RedirectToAction("Login", nameof(Account), new { returnUrl = Url.Action(nameof(AppointmentController.Theatre), "Appointment") });
            }

            var doctors = _doctorHandler.Doctors;

            if (doctors.Any())
            {
                //ViewData["Doctors"] = new SelectList(doctors.Select(u => new
                //{
                //    u.DoctorId,
                //    u.FirstName
                //}), "DoctorId", "FirstName");

                var doctorSelectList = new SelectList(doctors.Select(u => 
                    new SelectListItem() { Value = u.DoctorId.ToString(), Text = $"{u.FirstName} {u.LastName}" }), "Value", "Text");

                ViewData["Doctors"] = doctorSelectList;

                //var doctorSelectList = new SelectList(doctors.Select(u => new List<SelectListItem>
                //{
                //    new SelectListItem() { Value = u.DoctorId.ToString(), Text = $"{u.FirstName} {u.LastName}" }
                //}), "Value", "Text");


                //ViewData["Doctors"] = new SelectList(doctors.Select(u => new
                //{
                //    u.DoctorId,
                //    FullName = $"{u.FirstName} {u.LastName}"
                //}), "DoctorId", "FullName");



            }

            return View(model.AppointmentId > 0 ? model : new AppointmentViewModel());
            //return View(model);
        }

        [HttpPost("Appointment/Theatre")]
        public ActionResult TheatreApppointment(AppointmentViewModel appointmentViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _appointmentHandler.TheatreCreate(appointmentViewModel);
                    if (result != null)
                    {
                        return StatusCode((int)HttpStatusCode.OK);
                        //return RedirectToAction(nameof(Theatre));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Oops something went wrong please try again";
                        return View("Theatre");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Please Enter all the required fields";

                    return StatusCode((int) HttpStatusCode.BadRequest, ViewBag.ErrorMessage);

                    //return View("Theatre", appointmentViewModel);
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("Theatre");
            }
        }



 
        public ActionResult Create(AppointmentViewModel appointmentViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    appointmentViewModel.UserId = HttpContext.Session.GetObject<PersonViewModel>("User").UserId;   //  Gets the UserId of the currently logged in user

                    var result = _appointmentHandler.Create(appointmentViewModel);
                    if (result != null)
                    {
                        //return RedirectToAction(nameof(Index));
                        return StatusCode((int)HttpStatusCode.OK);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Oops something went wrong please try again";
                        //return View("Index");
                        return StatusCode((int)HttpStatusCode.BadRequest);
                    }
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest);
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("Index");
            }
        }

        [HttpPost("Update")]
        public ActionResult UpdateAppointment(AppointmentViewModel appointmentViewModel)
        {
            appointmentViewModel.UserId = HttpContext.Session.GetObject<PersonViewModel>("User").UserId;

            _appointmentHandler.Update(appointmentViewModel);
            return RedirectToAction(nameof(Theatre));
        }

        public ActionResult GetAppointment(string id)
        {
            try
            {
                if (id == null)
                {
                    ViewBag.ErrorMessage = "Please Enter a valid ID Number";
                    return View("Index");
                }

                var appointment = _appointmentHandler.GetPatientByIdNumber(id);
              
                return RedirectToAction(nameof(SearchPatient), appointment);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("Index");
            }
        }


        public JsonResult GetAppointments()
        {
            try
            {
                var appointments = _appointmentHandler.GetAppointments;
                ViewBag.Patients = appointments;
                return new JsonResult(appointments);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return null;
            }
        }
        public JsonResult GetTheatreAppointments()
        {
            try
            {
                var appointments = _appointmentHandler.GetTheatreAppointments;
                return new JsonResult(appointments);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return null;
            }
        }

        //[HttpGet("{doctorId}")]
        public JsonResult GetTheaterAppointmentsByDoctorId(int doctorId)
        {
            try
            {
                var appointments = _appointmentHandler.GetTheaterAppointmentsByDoctorId(doctorId);
                return new JsonResult(appointments);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return null;
            }
        }


        public ActionResult CancelAppointment(AppointmentViewModel model)
        {
            try
            {
                if (model == null)
                {
                    ViewBag.Error = "Ooops something went wrong please try again";
                    return View("Index");
                }
                model.AppointmentId = model.Id;
                var result = _appointmentHandler.CancelAppointment(model);
                if (result == null)
                {
                    ViewBag.ErrorMessage = "Oops sorry, failed to cancel the appointment please try again";
                    return View("Index");
                }
                return View("Index", result);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("Index");
            }
        }
    }
}