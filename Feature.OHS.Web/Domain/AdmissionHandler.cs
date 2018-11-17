using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels;
using Newtonsoft.Json;

namespace Feature.OHS.Web.Domain
{
    public class AdmissionHandler : IAdmissionHandler
    {
        private readonly IAPIIntegration _integration;

        public AdmissionHandler(IAPIIntegration integration)
        {
            _integration = integration;
        }

        public AdmissionViewModel AddAdmission(AdmissionViewModel admission)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/Admission/Create", admission, "https://dev-admissions-dot-medipark-hospital.appspot.com/", true);

            if (response != null)
            {
                var dynamicResponse = JsonConvert.DeserializeObject<AdmissionViewModel>(response.Message);
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
