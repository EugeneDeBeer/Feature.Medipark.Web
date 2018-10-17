using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using Newtonsoft.Json;

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
            var response = _aPIIntegration.ResponseFromAPIPost("", "v1/Staff/create", staff, "http://localhost:61036/", true);

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
            throw new System.NotImplementedException();
        }

        public dynamic UpdateStaff(StaffPayloadViewModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}