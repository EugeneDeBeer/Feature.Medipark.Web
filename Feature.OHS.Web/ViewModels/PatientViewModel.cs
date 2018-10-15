using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class PatientViewModel
    {

        public int PatientId { get; set; }
        public string ReferenceNumber { get; set; }
        public string Allergies { get; set; }
        public string Type { get; set; }
        public int PersonId { get; set; }
    }
}
