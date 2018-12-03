using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Settings;
using Feature.OHS.Web.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Feature.OHS.Web.Domain
{
    public class AppointmentHandler : IAppointmentHandler
    {
        private readonly IAPIIntegration _integration;
        private readonly IntegrationSettings _integrationSettings;

        public AppointmentHandler(IAPIIntegration aPIIntegration, IOptions<IntegrationSettings> integrationOptions)
        {
            _integration = aPIIntegration;
            _integrationSettings = integrationOptions.Value;
        }
        public IEnumerable<AppointmentViewModel> GetAppointments
        {
            get
            {
                var request = _integration.ResponseFromAPIGet("Get Patient", "v1/Appointment", _integrationSettings.AppointmentsDevApiUrl, "GET");

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
            var _response = _integration.ResponseFromAPIPost("", "v1/Appointment/Create", appointmentViewModel, _integrationSettings.AppointmentsDevApiUrl, true);
            // var _response = _integration.ResponseFromAPIPost("", "v1/Appointment/Create", appointmentViewModel, "https://localhost:44370/", true);

            if (_response != null)
            {
                var response = JsonConvert.DeserializeObject<AppointmentViewModel>(_response.Message);
                return response;

            }
            else
                return null;

        }

        public AppointmentViewModel GetAppointmentByIdNumber(string id)
        {
            var request = _integration.ResponseFromAPIGet("", "v1/Patient/Get/Patient?Id=" + id, "", "GET");
            if (request != null)
            {
                var _response = JsonConvert.DeserializeObject<AppointmentViewModel>(request.Message);
               
                    return _response;
                
                
            }
            else
            {
                return null;
            }
        }

        public AppointmentViewModel CancelAppointment(AppointmentViewModel model)
        {
            var _response = _integration.ResponseFromAPIPost("", "v1/Appointment/Cancel", model, _integrationSettings.AppointmentsDevApiUrl, true);

            if (_response != null)
            {
                var response = JsonConvert.DeserializeObject<dynamic>(_response.Message);
                return response;

            }
            else
                return null;
           
        }


        public dynamic Update(AppointmentViewModel appointmentViewModel)
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
            appointmentViewModel.AppointmentId = appointmentViewModel.Id;
            appointmentViewModel.End = appointmentViewModel.Start.AddMinutes(60);
            var _response = _integration.ResponseFromAPIPost("", "v1/Appointment/Update", appointmentViewModel, _integrationSettings.AppointmentsDevApiUrl, true);


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