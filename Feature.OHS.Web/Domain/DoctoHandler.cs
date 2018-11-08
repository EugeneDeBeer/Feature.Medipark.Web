using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Domain
{
    public class DoctoHandler : IDoctorHandler
    {
        private readonly IAPIIntegration _integration;

        public DoctoHandler(IAPIIntegration integration)
        {
            _integration = integration;
        }
      

        public DoctorNurseViewModel AddDoctor(DoctorNurseViewModel doctorVM)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/Person/Create", doctorVM, "http://localhost:61820/", true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<DoctorNurseViewModel>(response.Message);
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

        public DoctorNurseViewModel AddContact(DoctorNurseViewModel doctorVM)
        {
            var response = _integration.ResponseFromAPIPost("", "/v1/ContactAddress/Contact/Create", doctorVM, "http://localhost:61820", true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<DoctorNurseViewModel>(response.Message);
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

        public DoctorNurseViewModel AddAddress(DoctorNurseViewModel doctorVM)
        {
            var response = _integration.ResponseFromAPIPost("", "/v1/ContactAddress/Contact/Create", doctorVM, "http://localhost:61820", true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<DoctorNurseViewModel>(response.Message);
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

        public DoctorNurseViewModel AddPracticeInformation(DoctorNurseViewModel doctorVM)
        {
            var response = _integration.ResponseFromAPIPost("", "/v1/Doctor/Create/Doctor", doctorVM, "http://localhost:61820", true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<DoctorNurseViewModel>(response.Message);
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

        public DoctorNurseViewModel AddQualification(DoctorNurseViewModel doctorVM)
        {
            var response = _integration.ResponseFromAPIPost("", "/api/Qualification/Create", doctorVM, "http://localhost:61820", true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<DoctorNurseViewModel>(response.Message);
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
}
