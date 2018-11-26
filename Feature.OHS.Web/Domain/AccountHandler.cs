using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.ViewModels.Response;

namespace Feature.OHS.Web.Domain
{
    public class AccountHandler : IAccountHandler
    {
        private readonly IAPIIntegration _integration;

        public AccountHandler(IAPIIntegration integration)
        {
            _integration = integration;
        }

        public async Task<PersonViewModel> Register(PersonViewModel person)
        {
            //  Giving more information on what this event is for
            person.EventTypeDescription = "user registration";
            person.EventTypeShortDescription = "private practise";

            person.StatusTypeDescription = "Incomplete";
            person.StatusTypeShortDescription = "person";

            person.PersonTypeDescription = "individual";
            person.PersonTypeShortDescription = "person";

            person.EventDescription = $"Created  {person.FirstName} {person.LastName} as user";

            //  To be changed once we have the login module setup
            person.UserId = 1;

            //var response = _integration.ResponseFromAPIPost("", "v1/Registration/Create", person, "https://localhost:44358/", true);
            var response = _integration.ResponseFromAPIPost("", "v1/Registration/Create", person, "https://dev-feature-ohs-users-dot-medipark-hospital.appspot.com/", true);

            if (response != null)
            {
                var responseObject = JsonConvert.DeserializeObject<PersonViewModel>(response.Message);
                if (responseObject != null)
                {
                    return responseObject;
                }
                return null;
            }
            else { return null; }
        }

        public async Task<APIResponse> Login(LoginViewModel person)
        {          
            // var response = _integration.ResponseFromAPIPost("", "v1/Registration/Login", person, "https://localhost:44358/", true);
            var response = _integration.ResponseFromAPIPost("", "v1/Registration/Login", person, "https://dev-feature-ohs-users-dot-medipark-hospital.appspot.com/", true);

            if (response != null)
            {
                var responseObject = JsonConvert.DeserializeObject<APIResponse>(response.Message);
                return responseObject;
            }
            else { return null; }
        }
    }
}
