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

        public PatientPayloadViewModel AddPatient(PatientPayloadViewModel patient)
        {
            var response = _integration.ResponseFromAPIPost("","v1/Person/Create",patient, "https://dev-admissions-dot-medipark-hospital.appspot.com/", true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<PatientPayloadViewModel>(response.Message);
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

        public PatientPayloadViewModel GetPatientByIdNumber(string id)
        {
            var request = _integration.ResponseFromAPIGet("", "v1/Patient/Get/Patient?id=" + id, "https://dev-admissions-dot-medipark-hospital.appspot.com/", "GET");
            if (request != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<PatientPayloadViewModel>(request.Message);
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

        public IEnumerable<PatientPayloadViewModel> Patients
        {
            
            get
            {
                var request = _integration.ResponseFromAPIGet("Get Patient", "/v1/Person/PersonDetails", "https://dev-admissions-dot-medipark-hospital.appspot.com/", "GET");
                if (request != null)
                {
                    var dynamicResponse = JsonConvert.DeserializeObject<List<PatientPayloadViewModel>>(request.Message);
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

        
        public dynamic AddContact(PatientPayloadViewModel patient)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/ContactAddress/Contact/Create", patient, "https://dev-admissions-dot-medipark-hospital.appspot.com/", true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<PatientPayloadViewModel>(response.Message);
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

        public dynamic AddAddress(PatientPayloadViewModel patient)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/ContactAddress/Address/Create", patient, "https://dev-admissions-dot-medipark-hospital.appspot.com/", true);

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
     

        public dynamic UpdatePatient(PatientPayloadViewModel model)
        {

            var response = _integration.ResponseFromAPIPost("", "/v1/Patient/Update/Patient", model, "https://dev-admissions-dot-medipark-hospital.appspot.com/", true);

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

        public dynamic AddNextOfKin(PatientPayloadViewModel patient)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> SearchPatients(SearchParams condition, bool exactSearch = false)
        {
            try
            {
                var response = _integration.ResponseFromAPIGet("", $"v1/Patient/AdvanceSearch?FirstName={condition.FirstName}&LastName={condition.LastName}&IdNumber={condition.IdNumber}&PassportNumber={condition.PassportNumber}&HomeTel={condition.HomeTel}&WorkTel={condition.WorkTel}", "https://dev-search-dot-medipark-hospital.appspot.com", "GET");

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
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
