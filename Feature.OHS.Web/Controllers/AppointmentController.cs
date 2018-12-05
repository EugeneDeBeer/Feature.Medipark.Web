﻿using System;
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
            if (model == null)
                return View(new AppointmentViewModel());

            return View(model);
        }
        public ActionResult Search(AppointmentViewModel model)
        {
            if (model == null)
                return View(new AppointmentViewModel());

            return View(model);
        }
        [HttpPost("Appointment")]
        public ActionResult Create(AppointmentViewModel appointmentViewModel)
        {
            try
            {

                var result = _appointmentHandler.Create(appointmentViewModel);
                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = "Oops something went wrong please try again";
                    return View("Index");
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
            _appointmentHandler.Update(appointmentViewModel);
            return RedirectToAction(nameof(Index));
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

                var appointment = _appointmentHandler.GetAppointmentByIdNumber(id);
              
                return RedirectToAction(nameof(Search), appointment);
            }catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("Index");
            }
        }

        public JsonResult GetAppointments() {
            try { 
                var appointments = _appointmentHandler.GetAppointments;
                return new JsonResult(appointments);
            }catch(Exception e)
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
                if(result == null)
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