﻿using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Feature.OHS.Web.Domain
{
    public class AppointmentHandler : IAppointmentHandler
    {
        private readonly IAPIIntegration _integration;

        public AppointmentHandler(IAPIIntegration aPIIntegration) => _integration = aPIIntegration;

        public IEnumerable<AppointmentViewModel> GetAppointments
        {
            get
            {
                var request = _integration.ResponseFromAPIGet("Get Patient", "v1/Appointment/Appointments", "https://localhost:44370", "GET");
                if (request != null)
                {
                    var patientIndex = 0;
                    var Response = JsonConvert.DeserializeObject<IEnumerable<AppointmentViewModel>>(request.Message);
                    var appointmentList = new List<AppointmentViewModel>();

                    foreach (var item in Response)
                    {
                        appointmentList.Add(item);
                        appointmentList[patientIndex].Id = item.AppointmentId;
                        patientIndex++;
                    }

                    if (appointmentList != null)
                    {
                        return appointmentList;
                    }
                    return null;
                }
                else
                {
                    return null;
                }
            }
        }

        public AppointmentViewModel Create(AppointmentViewModel appointmentViewModel)
        {
            appointmentViewModel.AppointmentShortTypeDescription = "appointment";
            appointmentViewModel.AppointmentTypeDescription = "doctor";
            appointmentViewModel.EventDescription = $"creating doctor appointment for{appointmentViewModel.FirstName}";
            appointmentViewModel.EventTypeDescription = "book appointment";
            appointmentViewModel.EventTypeShortDescription = "private practice";
            appointmentViewModel.StatusTypeDescription = "booked";
            appointmentViewModel.StatusTypeShortDescription = "appointment";
            appointmentViewModel.PersonTypeDescription = "individual";
            appointmentViewModel.PersonTypeShortDescription = "person";
            //this value suppose to be recieved from the logged in user
            appointmentViewModel.UserId = 1;
            var tm = TimeSpan.Parse(appointmentViewModel.Time);
            appointmentViewModel.Start += tm;
            appointmentViewModel.End = appointmentViewModel.Start.AddMinutes(60);
            var _response = _integration.ResponseFromAPIPost("", "v1/Appointment/Create", appointmentViewModel, "https://localhost:44370/", true);

            if (_response != null)
            {
                var response = JsonConvert.DeserializeObject<AppointmentViewModel>(_response.Message);
                if (response != null)
                {
                    return response;
                }
                else
                    throw new Exception("failed to deserialize the response from the server");
            }
            else

                throw new Exception("the response from the server is null");
        }

        public AppointmentViewModel GetAppointmentByIdNumber(string id)
        {
            var request = _integration.ResponseFromAPIGet("", "/v1/Patient/Get/Patient?Id=" + id, "http://localhost:61820/", "GET");
            if (request != null)
            {
                var _response = JsonConvert.DeserializeObject<AppointmentViewModel>(request.Message);
                if (_response != null)
                {
                    return _response;
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public AppointmentViewModel Update(AppointmentViewModel appointmentViewModel)
        {
            appointmentViewModel.AppointmentShortTypeDescription = "appointment";
            appointmentViewModel.AppointmentTypeDescription = "doctor";
            appointmentViewModel.EventDescription = $"updating doctor appointment for{appointmentViewModel.FirstName}";
            appointmentViewModel.EventTypeDescription = "book appointment";
            appointmentViewModel.EventTypeShortDescription = "private practice";
            appointmentViewModel.StatusTypeDescription = "booked";
            appointmentViewModel.StatusTypeShortDescription = "appointment";
            appointmentViewModel.PersonTypeDescription = "individual";
            appointmentViewModel.PersonTypeShortDescription = "person";

            appointmentViewModel.UserId = 1;
            var tm = TimeSpan.Parse(appointmentViewModel.Time);
            appointmentViewModel.Start += tm;
            appointmentViewModel.End = appointmentViewModel.Start.AddMinutes(60);
            var _response = _integration.ResponseFromAPIPost("", "v1/Appointment/Update", appointmentViewModel, "https://localhost:44370/", true);

            if (_response != null)
            {
                var response = JsonConvert.DeserializeObject<dynamic>(_response.Message);
                if (response != null)
                {
                    return response;
                }
                else
                    throw new Exception("failed to deserialize the response from the server");
            }
            else

                throw new Exception("the response from the server is null");
        }
    }
}
