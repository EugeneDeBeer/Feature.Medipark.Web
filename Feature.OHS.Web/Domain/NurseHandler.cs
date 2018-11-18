using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Domain
{
    public class NurseHandler : INurseHandler
    {
        private readonly IAPIIntegration _integration;

        public NurseHandler(IAPIIntegration integration)
        {
            _integration = integration;
        }

        public IEnumerable<DoctorNurseViewModel> Nurses
        {
            get
            {
                var request = _integration.ResponseFromAPIGet("Get Nurses", "/v1/Doctor/Get/Nurses", "http://localhost:61820", "GET");
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

        public DoctorNurseViewModel AddAddress(DoctorNurseViewModel nurseVM)
        {
            var response = _integration.ResponseFromAPIPost("", "/v1/ContactAddress/Address/Create", nurseVM, "https://dev-admissions-dot-medipark-hospital.appspot.com/", true);

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

        public DoctorNurseViewModel AddContact(DoctorNurseViewModel nurseVM)
        {
            var response = _integration.ResponseFromAPIPost("", "/v1/ContactAddress/Contact/Create", nurseVM, "https://dev-admissions-dot-medipark-hospital.appspot.com/", true);

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

        public DoctorNurseViewModel AddNurse(DoctorNurseViewModel nurseVM)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/Person/Create", nurseVM, "https://dev-admissions-dot-medipark-hospital.appspot.com/", true);

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

        public DoctorNurseViewModel AddPracticeInformation(DoctorNurseViewModel nurseVM)
        {
            var response = _integration.ResponseFromAPIPost("", "/v1/Doctor/Create/Nurse", nurseVM, "https://dev-admissions-dot-medipark-hospital.appspot.com/", true);

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

        public DoctorNurseViewModel AddQualification(DoctorNurseViewModel nurseVM)
        {
            var response = _integration.ResponseFromAPIPost("", "/api/Qualification/Create", nurseVM, "https://dev-admissions-dot-medipark-hospital.appspot.com/", true);

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

        public DoctorNurseViewModel GetDoctorByIdNumber(string id)
        {
            throw new NotImplementedException();
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

        public dynamic UpdateNurse(DoctorNurseViewModel model)
        {
            var response = _integration.ResponseFromAPIPost("", "/v1/Doctor/Update/Doctor", model, "https://dev-admissions-dot-medipark-hospital.appspot.com/", true);

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
    }
}
