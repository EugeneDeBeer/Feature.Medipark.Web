using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;
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

        public dynamic AddNextOfKin(PatientViewModel patientViewModel)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/patient/create", patientViewModel, "https://admissions-dot-medipark-hospital.appspot.com/", true);

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

        public dynamic AddPatientContactDetails(PatientViewModel patientViewModel)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/patient/create", patientViewModel, "https://admissions-dot-medipark-hospital.appspot.com/", true);

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

        public dynamic AddPatientDetails(PatientViewModel patientViewModel)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/Person/Create", patientViewModel, "http://localhost:61820/", true);

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

        public dynamic GetPatient(int id, bool includeAllDetails = false)
        {
            throw new NotImplementedException();
        }

        //public dynamic AddPatient(PatientPayloadViewModel patient)
        //{
        //    var response = _integration.ResponseFromAPIPost("","v1/patient/create",patient, "https://admissions-dot-medipark-hospital.appspot.com/",true);

        //    if (response != null)
        //    {
        //        var dynamicResponse = JsonConvert.DeserializeObject<dynamic>(response.Message);
        //        if (dynamicResponse != null)
        //        {
        //            return dynamicResponse;
        //        }
        //        return null;
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}

        //public dynamic GetPatient(int id, bool includeAllDetails = false)
        //{
        //    return null;
        //}

        public dynamic UpdatePatient(PatientViewModel patient)
        {
            return null;
        }
    }
}
