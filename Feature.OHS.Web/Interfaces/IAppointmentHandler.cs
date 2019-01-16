﻿using Feature.OHS.Web.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Interfaces
{
    public interface IAppointmentHandler
    {
        IEnumerable<AppointmentViewModel> GetAppointments { get; }
        IEnumerable<AppointmentViewModel> GetTheatreAppointments { get; }
        IEnumerable<AppointmentViewModel> GetTheaterAppointmentsByDoctorId(int doctorId);

        AppointmentViewModel GetPatientByIdNumber(string id);
        List<AppointmentViewModel> GetAppointmentsByIdNumber(string id);
        AppointmentViewModel Create(AppointmentViewModel appointmentViewModel);
        AppointmentViewModel TheatreCreate(AppointmentViewModel appointmentViewModel);
        AppointmentViewModel CancelAppointment(AppointmentViewModel model);
        dynamic Update(AppointmentViewModel appointmentViewModel);
    }
}