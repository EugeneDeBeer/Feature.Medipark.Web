using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Settings;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IDoctorHandler _doctorHandler;

        public AppointmentHandler(IAPIIntegration aPIIntegration, IOptions<IntegrationSettings> integrationOptions, IDoctorHandler doctorHandler)
        {
            _integration = aPIIntegration;
            _integrationSettings = integrationOptions.Value;
            _doctorHandler = doctorHandler;
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

        public IEnumerable<AppointmentViewModel> GetTheatreAppointments
        {
            get
            {
                var request = _integration.ResponseFromAPIGet("Get Patient", "Get/Appointments", _integrationSettings.SearchDevApiUrl, "GET");

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

            var tm = TimeSpan.Parse(appointmentViewModel.Time);
            appointmentViewModel.Start += tm;
            appointmentViewModel.End = appointmentViewModel.Start.AddMinutes(60);
            var _appointmentResponse = _integration.ResponseFromAPIPost("", "v1/Appointment/Create", appointmentViewModel, _integrationSettings.AppointmentsDevApiUrl, true);
            //var _appointmentResponse = _integration.ResponseFromAPIPost("", "v1/Appointment/Create", appointmentViewModel, "https://localhost:44370", true);

            if (_appointmentResponse != null)
            {
                var response = JsonConvert.DeserializeObject<AppointmentViewModel>(_appointmentResponse.Message);

                var patientContact = new AppointmentViewModel()
                {
                    PersonId = response.PersonId,
                    CellPhone = appointmentViewModel.CellPhone,
                    Email1 = appointmentViewModel.Email1
                };
                var _contactResponse = _integration.ResponseFromAPIPost("", "/v1/ContactAddress/Contact/Create", patientContact, _integrationSettings.AdmissionsDevApiUrl, true);

                if (_contactResponse != null)
                {
                    var response2 = JsonConvert.DeserializeObject<AppointmentViewModel>(_appointmentResponse.Message);

                    return new AppointmentViewModel()
                    {
                        FirstName = response.FirstName,
                        LastName = response.LastName,
                        CellPhone = response2.CellPhone,
                        Email1 = response2.Email1,
                        Description = response.Description,
                        Title = response.Title
                    };
                }
                else throw new Exception(_contactResponse.Message);
            }
            else throw new Exception(_appointmentResponse.Message);
        }

        public AppointmentViewModel TheatreCreate(AppointmentViewModel appointmentViewModel)
        {
            appointmentViewModel.AppointmentShortTypeDescription = "appointment";
            appointmentViewModel.AppointmentTypeDescription = "theatre";
            appointmentViewModel.EventDescription = $"creating theatre appointment for{appointmentViewModel.FirstName}";
            appointmentViewModel.EventTypeDescription = "book appointment";
            appointmentViewModel.EventTypeShortDescription = "private practice";
            appointmentViewModel.StatusTypeDescription = "booked";
            appointmentViewModel.StatusTypeShortDescription = "appointment";
            appointmentViewModel.PersonTypeDescription = "individual";
            appointmentViewModel.PersonTypeShortDescription = "person";

            var tm = TimeSpan.Parse(appointmentViewModel.Time);
            appointmentViewModel.Start += tm;
            appointmentViewModel.End = appointmentViewModel.Start.AddMinutes(60);
            var _appointmentResponse = _integration.ResponseFromAPIPost("", "/v1/Appointment/Create/Theatre", appointmentViewModel, _integrationSettings.AppointmentsDevApiUrl, true);
          
            if (_appointmentResponse != null)
            {
                var response = JsonConvert.DeserializeObject<AppointmentViewModel>(_appointmentResponse.Message);

                return response;
            }
            else throw new Exception(_appointmentResponse.Message);
        }

        public AppointmentViewModel GetPatientByIdNumber(string id)
        {
            var request = _integration.ResponseFromAPIGet("", "v1/Patient/Get/Patient?Id=" + id, _integrationSettings.AdmissionsDevApiUrl, "GET");

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

        public List<AppointmentViewModel> GetAppointmentsByIdNumber(string id)
        {
            var request = _integration.ResponseFromAPIGet("", "/Get/Appointment?Id=" + id, _integrationSettings.SearchDevApiUrl, "GET");

            if (request != null)
            {
                var _response = JsonConvert.DeserializeObject<List<AppointmentViewModel>>(request.Message);

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

        public List<SelectListItem> AvailableTime(string time)
        {
            return new List<SelectListItem>() {
            new SelectListItem {Value = "08:00",  Text = "08:00 "},
            new SelectListItem {Value = "09:00",  Text = "09:00 "},
            new SelectListItem {Value = "10:00",  Text = "10:00 "},
            new SelectListItem {Value = "11:00",  Text = "11:00 "},
            new SelectListItem {Value = "12:00",  Text = "12:00 "},
            new SelectListItem {Value = "13:00",  Text = "13:00 "},
            new SelectListItem {Value = "14:00",  Text = "14:00 "},
            new SelectListItem {Value = "15:00",  Text = "15:00 "},
            new SelectListItem {Value = "16:00",  Text = "16:00 "}
            };
        }
    }
}