using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Settings;
using Feature.OHS.Web.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Domain
{
    public class DoctorHandler : IDoctorHandler
    {
        private readonly IAPIIntegration _integration;
        private readonly IntegrationSettings _integrationSettings;
        public DoctorHandler(IAPIIntegration integration, IOptions<IntegrationSettings> integrationSettings)
        {
            _integration = integration;
            _integrationSettings = integrationSettings.Value;
        }
      

        public DoctorNurseViewModel AddDoctor(DoctorNurseViewModel doctorVM)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/Person/Create", doctorVM, _integrationSettings.AdmissionsDevApiUrl, true);

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
            var response = _integration.ResponseFromAPIPost("", "/v1/ContactAddress/Contact/Create", doctorVM, _integrationSettings.AdmissionsDevApiUrl, true);

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
                //var request = _integration.ResponseFromAPIGet("Get Doctors", "v1/Practice/Get/Doctors", "http://localhost:51020", "GET");
                //var request = _integration.ResponseFromAPIGet("Get Doctors", "v1/Doctor/Get/Doctors", "http://localhost:51020" /*_integrationSettings.AdmissionsDevApiUrl*/, "GET");

                var request = _integration.ResponseFromAPIGet("Get Doctors", "v1/Practice/Get/Doctors", _integrationSettings.AdmissionsDevApiUrl, "GET");
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
            var request = _integration.ResponseFromAPIGet("", "v1/Doctor/Get/DoctorNurse?Id=" + id, _integrationSettings.AdmissionsDevApiUrl, "GET");
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

            var response = _integration.ResponseFromAPIPost("", "/v1/Doctor/Update/Doctor", model, _integrationSettings.AdmissionsDevApiUrl, true);

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
            var response = _integration.ResponseFromAPIPost("", "/v1/ContactAddress/Address/Create", doctorVM, _integrationSettings.AdmissionsDevApiUrl, true);

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
            var response = _integration.ResponseFromAPIPost("", "/v1/Doctor/Create/Doctor", doctorVM, _integrationSettings.AdmissionsDevApiUrl, true);

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
            var response = _integration.ResponseFromAPIPost("", "/api/Qualification/Create", doctorVM, _integrationSettings.AdmissionsDevApiUrl, true);

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

        public dynamic SearchDoctors(SearchParams condition, bool exactSearch = false)
        {
            try
            {
                var response = _integration.ResponseFromAPIGet("", $"v1/Doctor/AdvanceSearch?FirstName={condition.FirstName}&LastName={condition.LastName}&IdNumber={condition.IdNumber}&PassportNumber={condition.PassportNumber}&HomeTel={condition.HomeTel}&WorkTel={condition.WorkTel}", "http://localhost:50566/", "GET");

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
