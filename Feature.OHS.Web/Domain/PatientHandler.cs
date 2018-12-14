﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.Settings;
using Feature.OHS.Web.ViewModels;
using Feature.OHS.Web.ViewModels.Response;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Feature.OHS.Web.Domain
{
    public class PatientHandler : IPatientHandler
    {
        private readonly IAPIIntegration _integration;       
        private readonly IntegrationSettings _integrationSettings;

        public PatientHandler(IAPIIntegration aPIIntegration, IOptions<IntegrationSettings> integrationOptions)
        {
            _integration = aPIIntegration;
            _integrationSettings = integrationOptions.Value;
        }

        public PatientPayloadViewModel AddPatient(PatientPayloadViewModel patient)
        {
            //var response = _integration.ResponseFromAPIPost("","v1/Person/Create",patient, "http://localhost:61820/", true);
            var response = _integration.ResponseFromAPIPost("", "v1/Person/Create", patient, _integrationSettings.AdmissionsDevApiUrl, true);

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
            //var request = _integration.ResponseFromAPIGet("", "v1/Patient/Get/Patient?id=" + id, "http://localhost:61820/", "GET");
            var request = _integration.ResponseFromAPIGet("", "v1/Patient/Get/Patient?id=" + id, _integrationSettings.AdmissionsDevApiUrl, "GET");

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
                //var request = _integration.ResponseFromAPIGet("Get Patient", "v1/Patient/Get/Patients", "http://localhost:61820/", "GET");
                var request = _integration.ResponseFromAPIGet("Get Patient", "v1/Patient/Get/Patients", _integrationSettings.AdmissionsDevApiUrl, "GET");

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
            //var response = _integration.ResponseFromAPIPost("", "v1/ContactAddress/Contact/Create", patient, "http://localhost:61820/", true);
            var response = _integration.ResponseFromAPIPost("", "v1/ContactAddress/Contact/Create", patient, _integrationSettings.AdmissionsDevApiUrl, true);

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
            //var response = _integration.ResponseFromAPIPost("", "v1/ContactAddress/Address/Create", patient, "http://localhost:61820/", true);
            var response = _integration.ResponseFromAPIPost("", "v1/ContactAddress/Address/Create", patient, _integrationSettings.AdmissionsDevApiUrl, true);

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

            //var response = _integration.ResponseFromAPIPost("", "/v1/Patient/Update/Patient", model, "http://localhost:61820/", true);
            var response = _integration.ResponseFromAPIPost("", "/v1/Patient/Update/Patient", model, _integrationSettings.AdmissionsDevApiUrl, true);

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

        public dynamic SearchPatients(SearchParams condition, bool exactSearch = false)
        {
            try
            {
                //var response = _integration.ResponseFromAPIGet("", $"v1/Patient/AdvanceSearch?FirstName={condition.FirstName}&LastName={condition.LastName}&IdNumber={condition.IdNumber}&PassportNumber={condition.PassportNumber}&HomeTel={condition.HomeTel}&WorkTel={condition.WorkTel}", "http://localhost:50566", "GET");
                var response = _integration.ResponseFromAPIGet("", $"v1/Patient/AdvanceSearch?FirstName={condition.FirstName}&LastName={condition.LastName}&IdNumber={condition.IdNumber}&PassportNumber={condition.PassportNumber}&HomeTel={condition.HomeTel}&WorkTel={condition.WorkTel}", _integrationSettings.AdmissionsDevApiUrl, "GET");

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
