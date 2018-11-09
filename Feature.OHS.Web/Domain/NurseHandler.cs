using Feature.OHS.Web.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Domain
{
    public class NurseHandler: INurseHandler
    {
        private readonly IAPIIntegration _integration;

        public NurseHandler(IAPIIntegration integration)
        {
            _integration = integration;
        }

        public dynamic GetNurse(int id)
        {
            var response = _integration.ResponseFromAPIGet("", $"v1/Nurse/GetNurse/{id}", "http://localhost:50566/", "GET");

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

        public dynamic GetNurses()
        {
            var response = _integration.ResponseFromAPIGet("", "v1/Nurse/GetNurses", "http://localhost:50566/", "GET");

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
