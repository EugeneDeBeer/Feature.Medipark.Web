﻿using DevOne.Security.Cryptography.BCrypt;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.Settings;
using Feature.OHS.Web.ViewModels.Response;
using Microsoft.Extensions.Options;

namespace Feature.OHS.Web.Domain
{
    public class AccountHandler : IAccountHandler
    {
        private readonly IAPIIntegration _integration;
        private readonly IntegrationSettings _integrationSettings;

        public AccountHandler(IAPIIntegration integration, IOptions<IntegrationSettings> integrationOptions)
        {
            _integration = integration;
            _integrationSettings = integrationOptions.Value;
        }

        public async Task<PersonViewModel> Register(PersonViewModel person)
        {
            //  Giving more information on what this event is for
            person.EventTypeDescription = "user registration";
            person.EventTypeShortDescription = "private practice";

            person.StatusTypeDescription = "Incomplete";
            person.StatusTypeShortDescription = "person";

            person.PersonTypeDescription = "individual";
            person.PersonTypeShortDescription = "person";

            person.EventDescription = $"Created  {person.FirstName} {person.LastName} as user";

            //  To be changed once we have the login module setup
            //person.UserId = 1;

            //var response = _integration.ResponseFromAPIPost("", "v1/Registration/Create", person, "https://localhost:44358/", true);
            var response = _integration.ResponseFromAPIPost("", "v1/Registration/Create", person, _integrationSettings.UsersDevApiUrl, true);

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
            //var response = _integration.ResponseFromAPIPost("", "v1/Registration", person, "https://localhost:44358/", true);
            var response = _integration.ResponseFromAPIPost("", "v1/Registration", person, _integrationSettings.UsersDevApiUrl, true);

            //var responseObject = JsonConvert.DeserializeObject<APIResponse>(response.Message);
            //return responseObject;
            return response;
        }

        public async Task<APIResponse> GetAllRoles()
        {
            //var response = _integration.ResponseFromAPIGet("Get Roles", "v1/Registration/GetRoles", "https://localhost:5001/", "GET");
            var response = _integration.ResponseFromAPIGet("Get Roles", "v1/Registration/GetRoles", _integrationSettings.UsersDevApiUrl, "GET");

            return response;
        }

        //public async Task<APIResponse> FindUserByEmail(ForgotPasswordViewModel model)
        public async Task<UserViewModel> FindUserByEmail(ForgotPasswordViewModel model)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/Registration/FindUserByEmail", model, _integrationSettings.UsersDevApiUrl, true);
            //var response = _integration.ResponseFromAPIPost("", "v1/Registration/FindUserByEmail", model, "https://localhost:5001/", true);

            if (response != null)
            {
                //var responseObject = JsonConvert.DeserializeObject<APIResponse>(response.Message);
                var responseObject = JsonConvert.DeserializeObject<UserViewModel>(response.Message);
                return responseObject;
            }
            else
            {
                return null;
            }
        }

        public async Task<APIResponse> SetUserPasswordResetToken(UpdatePasswordResetTokenModel model)
        {
            var response = _integration.ResponseFromAPIPost("", "v1/Registration/SetUserPasswordResetToken", new { userId = model.UserId, resetToken = model.ResetToken }, _integrationSettings.UsersDevApiUrl, true);

            if (response != null)
            {
                var responseObject = JsonConvert.DeserializeObject<APIResponse>(response.Message);
                return responseObject;
            }
            else
            {
                return null;
            }
        }

        public async Task<APIResponse> ResetPasswordAsync(ResetPasswordViewModel model)
        {
            // encrypt before transmission
            model.Password = BCryptHelper.HashPassword(model.Password, BCryptHelper.GenerateSalt());
            model.ConfirmPassword = model.Password;
            var response = _integration.ResponseFromAPIPost("", "v1/Registration/ResetPasswordAsync", model, _integrationSettings.UsersDevApiUrl, true);

            if (response != null)
            {
                if (response.Success)
                {
                    var responseObject = JsonConvert.DeserializeObject<APIResponse>(response.Message);
                    return responseObject;
                }

                return null;
            }
            else
            {
                return null;
            }
        }
          public String GeneratePasswordResetToken()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }

        public dynamic SendEmail(MailViewModel mailViewModel)
        {

            var response = _integration.ResponseFromAPIPost("", "/v1/Mail/Mail", mailViewModel, "https://localhost:44345", true);
            //var response = _integration.ResponseFromAPIPost("", "/v1/Mail/Mail", mailViewModel, _integrationSettings.EmailDevApiUrl, true);

            if (response != null)
            {
                if (response.Success)
                {
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(response.Message);
                    return responseObject;
                }

                return null;
            }
            else
            {
                return null;
            }
            //MailMessage mail = new MailMessage(from, to);
            //SmtpClient client = new SmtpClient();
            //client.Port = 25;
            ////client.Port = 465;
            ////client.Port = 587;            

            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //client.Host = "smtp.gmail.com";

            ////  Added by TS MOTSWAINE
            //client.EnableSsl = true;

            //NetworkCredential credentials = new System.Net.NetworkCredential("tsepo@mgibagroup.com", "Omeyah@18");

            //client.Credentials = credentials;
            //mail.IsBodyHtml = true;

            //mail.Subject = subject;
            //mail.Body = body;


            //client.Send(mail);


        }
    }
}
