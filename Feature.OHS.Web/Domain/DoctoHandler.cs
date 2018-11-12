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

        public IEnumerable<DoctorNurseViewModel> Doctors
        {

            get
            {
                var request = _integration.ResponseFromAPIGet("Get Doctoers", "v1/Doctor/Get/Doctors", "http://localhost:61820", "GET");
                if (request != null)
                {
                    var dynamicResponse = JsonConvert.DeserializeObject<List<DoctorNurseViewModel>>(request.Message);
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
        public DoctorNurseViewModel GetDoctorByIdNumber(string id)
        {
            var request = _integration.ResponseFromAPIGet("", "/v1/Doctor/Get/Doctor?id=" + id, "http://localhost:61820", "GET");
            if (request != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<DoctorNurseViewModel>(request.Message);
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
        public dynamic UpdateDoctor(DoctorNurseViewModel model)
        {

            var response = _integration.ResponseFromAPIPost("", "/v1/Doctor/Update/Doctor", model, "http://localhost:61820/", true);

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
        public DoctorNurseViewModel AddAddress(DoctorNurseViewModel doctorVM)
        {
            var response = _integration.ResponseFromAPIPost("", "/v1/ContactAddress/Address/Create", doctorVM, "http://localhost:61820", true);

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
