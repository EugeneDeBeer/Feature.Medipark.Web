using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections;
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

                var request = _integration.ResponseFromAPIGet("Get Patient", "v1/Appointment/Appointments", "https://localhost:44358", "GET");
                if (request != null)
                {
                    var Response = JsonConvert.DeserializeObject<IEnumerable<AppointmentViewModel>>(request.Message);
                    if (Response != null)
                    {
                        return Response;
                    }
                    return null;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}