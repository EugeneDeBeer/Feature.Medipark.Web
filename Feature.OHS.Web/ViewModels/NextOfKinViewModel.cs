using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class NextOfKinViewModel
    {
        public string NokName { get; set; }
        public string NokSurname { get; set; }
        public int PatientId  { get; set; }
        public string nokRelationship { get; set; }
        public string Relation { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public string nokEmail { get; set; }
        public string NokAddress1 { get; set; }
        public string NokAddress2 { get; set; }
        public string NokAddress3 { get; set; }
    }
}
