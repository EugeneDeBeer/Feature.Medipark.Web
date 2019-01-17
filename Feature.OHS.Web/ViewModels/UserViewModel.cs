using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class UserViewModel
    {
        //public string UserName { get; set; }
        //public  string Password { get; set; }

        //public int UserId { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }
        //public int? UserRoleId { get; set; }

        public int UserId { get; set; }
        public int DoctorId { get; set; }
        public string UserName { get; set; }
        public int? EventId { get; set; }
        public string Password { get; set; }
        public int? UserRoleId { get; set; }
        public string EmployeeNumber { get; set; }
        public int PersonId { get; set; }
        public string EventTypeShortDescription { get; set; }
        public string EventTypeDescription { get; set; }
        public string EventDescription { get; set; }
        public string UserEmail { get; set; }

        //  To be used to distinguish doctors from Receptionists when assigning Roles
        public bool IsDoctor { get; set; }
    }
}
