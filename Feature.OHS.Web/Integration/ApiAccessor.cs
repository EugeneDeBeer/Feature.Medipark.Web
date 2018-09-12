using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;

namespace Feature.OHS.Web.Integration
{
    public class ApiAccessor:IApiAccessor
    {
        private HttpClient _client;

        public HttpClient GetHttpClient()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri("https://admissions-dot-medipark-hospital.appspot.com/v1/")
                //BaseAddress = new Uri("http://localhost:51473/v1/")
            };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return _client;
        }
    }
}
