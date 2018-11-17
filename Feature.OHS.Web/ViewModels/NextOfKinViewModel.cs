using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class NextOfKinViewModel
    {
        public string nokName { get; set; }
        public string nokSurname { get; set; }
        public int PatientId  { get; set; }
        public string nokRelationship { get; set; }
        public string Relation { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public string nokEmail { get; set; }
    }
}
