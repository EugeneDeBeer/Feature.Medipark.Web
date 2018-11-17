using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Integration
{
    public class APIIntegration : IAPIIntegration
    {
        private readonly IServiceAuthentication _serviveAuthentication;

        public APIIntegration(IServiceAuthentication serviveAuthentication)
        {
            _serviveAuthentication = serviveAuthentication;

        }

        private string GenerateToken(string serviceName)
        {
            return _serviveAuthentication.GenerateToken("Medipark_JWT_Auth", serviceName, new TimeSpan(0, 15, 0));
        }

        public APIResponse ResponseFromAPIPost<T>(string serviceName, string method, T passedObject, string apiUrl, bool authenticate) where T : class
        {
            return ResponseFromAPIPost(serviceName, method, passedObject, apiUrl, authenticate, string.Empty);
        }

        public APIResponse ResponseFromAPIPost<T>(string serviceName, string method, T passedObject, string apiUrl, bool authenticate, string Customtoken) where T : class
        {
            var token = string.Empty;
            if (string.IsNullOrEmpty(Customtoken))
            {
                token = authenticate ? GenerateToken(serviceName) : serviceName;
            }
            else
            {
                token = Customtoken;
            }

            var message = "";

            var handler = new HttpClientHandler();

            using (var client = new HttpClient(handler)
            {
                BaseAddress = new Uri(apiUrl)
            })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var stringContent = JsonConvert.SerializeObject(passedObject);
                var httpContent = new StringContent(stringContent, Encoding.UTF8, "application/json");


                var response = client.PostAsync(method, httpContent).GetAwaiter().GetResult();
                message = response.Content.ReadAsStringAsync().Result;

                var mesTemp = message;


                return response.IsSuccessStatusCode ? new APIResponse
                {
                    Success = true,
                    Message = message,
                    StatusCode = response.StatusCode
                } : new APIResponse
                {
                    Success = false,
                    Message = message,
                    StatusCode = response.StatusCode
                };
            }
        }

        public APIResponse ResponseFromAPIGet(string serviceName, string method, string apiUrl, string authHeader)
        {
            var token = GenerateToken(serviceName);
            var message = "";
            var handler = new HttpClientHandler();

            using (var client = new HttpClient(handler)
            {
                BaseAddress = new Uri(apiUrl)
            })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                if (!string.IsNullOrEmpty(authHeader))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeader);
                try
                {


                    var response = client.GetAsync(method).GetAwaiter().GetResult();
                    message = response.Content.ReadAsStringAsync().Result;

                    return response.IsSuccessStatusCode ? new APIResponse
                    {
                        Success = true,
                        Message = message,
                        StatusCode = response.StatusCode
                    } : new APIResponse
                    {
                        Success = false,
                        Message = message,
                        StatusCode = response.StatusCode
                    };
                }
                catch (Exception e)
                {
                    return new APIResponse
                    {
                        Success = false,
                        Message = e.Message,
                        StatusCode = HttpStatusCode.InternalServerError
                    };
                }
            }
        }
    }
}
