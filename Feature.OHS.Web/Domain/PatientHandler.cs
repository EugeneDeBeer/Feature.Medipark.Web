﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels;
using Newtonsoft.Json;

namespace Feature.OHS.Web.Domain
{
    public class PatientHandler:IPatientHandler
    {
        private readonly IApiAccessor _apiAccessor;
        //private HttpClient client;
        public PatientHandler(IApiAccessor apiAccessor)
        {
            _apiAccessor = apiAccessor;

            //url: 'https://admissions-dot-medipark-hospital.appspot.com/v1/Patient/create',

            //client = new HttpClient()
            //{
            //    BaseAddress = new Uri("https://admissions-dot-medipark-hospital.appspot.com/v1/")
            //};
            //client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> AddPatient(PatientViewModel patient)
        {
            HttpResponseMessage res = await _apiAccessor.GetHttpClient().PostAsJsonAsync<PatientViewModel>("Patient/create", patient);

            if (res.IsSuccessStatusCode)
            {
                var empResponse = res.Content.ReadAsStringAsync().Result;

                var newPatient = JsonConvert.DeserializeObject<PatientViewModel>(empResponse);

                return true;
            }

            return false;
        }
    }
}
