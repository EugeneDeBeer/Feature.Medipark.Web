using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Feature.OHS.Web.Domain
{
    public class StaffHandler : IStaffHandler
    {
        private readonly IAPIIntegration _aPIIntegration;
        public StaffHandler(IAPIIntegration aPIIntegration)
        {
            _aPIIntegration = aPIIntegration;
        }
        public dynamic AddStaff(StaffPayloadViewModel staff)
        {
            var response = _aPIIntegration.ResponseFromAPIPost("", "v1/Staff/create", staff, "https://dev-feature-medipark-admissions-dot-medipark-hospital.appspot.com/", true);

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

        public dynamic GetStaff(int id, bool includeAllDetails = false)
        {
            var request = _aPIIntegration.ResponseFromAPIGet("Get Staff", "/v1/Staff/Edit", id.ToString(),"[Authorization]");
            if (request != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<dynamic>(request.Message);
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

        public IEnumerable<StaffPayloadViewModel> Staffs
        {
            get
            {
                var request = _aPIIntegration.ResponseFromAPIGet("Get Staffs", "/v1/Person/Persons", "https://dev-feature-medipark-admissions-dot-medipark-hospital.appspot.com/", "GET");
                if (request != null)
                {
                    var dynamicResponse = JsonConvert.DeserializeObject<List<StaffPayloadViewModel>>(request.Message);
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

  

        public dynamic UpdateStaff(StaffPayloadViewModel model)
        {
            var response = _aPIIntegration.ResponseFromAPIPost("", "v1/Staff/Edit", model, "https://dev-feature-medipark-admissions-dot-medipark-hospital.appspot.com/", true);

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

        public dynamic GetStaffByIdNumber(string id)
        {
            var request = _aPIIntegration.ResponseFromAPIGet("", "/v1/Staff/Edit?id="+id, "https://dev-feature-medipark-admissions-dot-medipark-hospital.appspot.com", "GET");
            if (request != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<StaffPayloadViewModel>(request.Message);
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