﻿using System;
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

        public PatientViewModel AddContact(PatientViewModel patient)
        {
            var response = _integration.ResponseFromAPIPost("", "/v1/ContactAddress/Contact/Create", patient, "http://localhost:61820", true);

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

        public PatientViewModel AddAddress(PatientViewModel patient)
        {
            var response = _integration.ResponseFromAPIPost("", "/v1/ContactAddress/Contact/Create", patient, "http://localhost:61820", true);

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
        public dynamic GetPatient(int id, bool includeAllDetails = false)
        {
            return null;
        }

        public dynamic UpdatePatient(PatientPayloadViewModel patient)
        {
            return null;
        }

        public PatientViewModel AddNextOfKin(PatientViewModel patient)
        {
            throw new NotImplementedException();
        }
    }
}
