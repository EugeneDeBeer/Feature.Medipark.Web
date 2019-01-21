using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class DashboardViewModel
    {
        public string Title { get; set; }
        
        public string Initials { get; set; }
        // [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        // [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        
        public string IdNumber { get; set; }
        public int PersonId { get; set; }
        public int UserId { get; set; }
        public int? PatientId { get; set; }
        
        //public string Telephone1 { get; set; }
        //public string Telephone2 { get; set; }
        //public string Telephone3 { get; set; }
        //public string HomeTelephone { get; set; }
        //public string WorkTelephone { get; set; }
        public string CellPhone { get; set; }

        public string Email1 { get; set; }
        public string Email2 { get; set; }
       
    }
}
