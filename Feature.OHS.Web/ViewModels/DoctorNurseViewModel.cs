using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class DoctorNurseViewModel
    {
        public string PracticeNumber { get; set; }
        public int PersonId { get; set; }
        public string HpcnaregistrationNumber { get; set; }
        public int NumberOfYearsInPractice { get; set; }
        public string RegistrationNumber { get; set; }
        public string Email1 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string CellPhone { get; set; }
    }
}
