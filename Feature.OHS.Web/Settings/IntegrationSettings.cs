using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Settings
{
    public class IntegrationSettings
    {
        public string AppointmentsDevApiUrl { get; set; }

        public string UsersDevApiUrl { get; set; }

        public string SearchDevApiUrl { get; set; }
        
        public string AdmissionsDevApiUrl { get; set; }
        public string HospitalWardsApiUrl { get; set; }
    }
}