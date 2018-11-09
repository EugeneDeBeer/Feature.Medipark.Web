using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using Feature.OHS.Web.ViewModels.Response;
using Newtonsoft.Json;

namespace Feature.OHS.Web.Domain
{
    public class PatientHandler : IPatientHandler
    {
        private readonly IAPIIntegration _integration;
       
        public PatientHandler(IAPIIntegration integration)
        {
            _integration = integration;

        }

        public PatientViewModel AddPatient(PatientViewModel patient)
        {
            var response = _integration.ResponseFromAPIPost("","v1/Person/Create",patient, "http://localhost:61820/", true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<PatientViewModel>(response.Message);
                if (dynamicResponse != null)
                {
                   
                    return dynamicResponse;
                }
                return null;
            }
            else
            {
                return null;
            }

        }

        public PatientViewModel GetPatientByIdNumber(string id)
        {
            var request = _integration.ResponseFromAPIGet("", "/v1/Patient/Get/Patient?id=" + id, "http://localhost:61820", "GET");
            if (request != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<PatientViewModel>(request.Message);
                if (dynamicResponse != null)
                {
                    return dynamicResponse;
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<PatientViewModel> Patients
        {
            
            get
            {
                var request = _integration.ResponseFromAPIGet("Get Patient", "/v1/Person/PersonDetails", "http://localhost:61820", "GET");
                if (request != null)
                {
                    var dynamicResponse = JsonConvert.DeserializeObject<List<PatientViewModel>>(request.Message);
                    if (dynamicResponse != null)
                    {
                        return dynamicResponse;
                    }
                    return null;
                }
                else
                {
                    return null;
                }
            }
        }

        
        public dynamic AddContact(PatientViewModel patient)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/ContactAddress/Contact/Create", patient, "http://localhost:61820/", true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<PatientViewModel>(response.Message);
                if (dynamicResponse != null)
                {
                    return dynamicResponse;
                }
                return null;
            }
            else
            {
                return null;
            }

        }

        public dynamic AddAddress(PatientViewModel patient)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/ContactAddress/Address/Create", patient, "http://localhost:61820/", true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<dynamic>(response.Message);
                if (dynamicResponse != null)
                {
                    return dynamicResponse;
                }
                return null;
            }
            else
            {
                return null;
            }

        }
     

        public dynamic UpdatePatient(PatientViewModel model)
        {

            var response = _integration.ResponseFromAPIPost("", "/v1/Patient/Update/Patient", model, "http://localhost:61836/", true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<dynamic>(response.Message);
                if (dynamicResponse != null)
                {
                    return dynamicResponse;
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public dynamic AddNextOfKin(PatientViewModel patient)
        {
            throw new NotImplementedException();
        }
    }
}
