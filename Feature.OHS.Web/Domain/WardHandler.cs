using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Domain
{
    public class WardHandler : IWard
    {
        private readonly IAPIIntegration _integration;

        public WardHandler(IAPIIntegration integration)
        {
            _integration = integration;

        }

       public dynamic CreateBed(BedViewModel bed)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/Ward/Create/bed", bed, "https://dev-admissions-dot-medipark-hospital.appspot.com/", true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<BedViewModel>(response.Message);
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

       public  dynamic CreateWard(WardViewModel ward)
        {
            ward.EventShortDescription = "ward";
            ward.EventDescription = "Created";
            var response = _integration.ResponseFromAPIPost("", "v1/Ward/create", ward, "https://dev-feature-ohs-hopsitalwards-dot-medipark-hospital.appspot.com/", true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<WardViewModel>(response.Message);
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

        public dynamic EditBed(BedViewModel bed)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/Ward/edit/bed", bed, "https://dev-admissions-dot-medipark-hospital.appspot.com/", true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<BedViewModel>(response.Message);
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

        public dynamic EditWard(WardViewModel ward)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/Ward/edit", ward, "https://dev-admissions-dot-medipark-hospital.appspot.com/", true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<WardViewModel>(response.Message);
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
