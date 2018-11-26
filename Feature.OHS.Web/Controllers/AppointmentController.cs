﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;
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
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAppointments() {
            var appointments = _appointmentHandler.GetAppointments;
            return new JsonResult(appointments);
        }

    }
}