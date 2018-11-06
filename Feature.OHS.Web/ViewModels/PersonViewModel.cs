using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class PersonViewModel
    {
        public int UserId { get; set; }
        public DateTime? Created { get; set; }
        public string Title { get; set; }
        public string Initials { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int personId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public string PassportNumber { get; set; }
        public string Occupation { get; set; }
        public string IdentityType { get; set; }
        public string Citizenship { get; set; }

    }
}
