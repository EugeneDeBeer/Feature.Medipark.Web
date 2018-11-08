using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class PatientViewModel
    {

        public string ReferenceNumber { get; set; }
        public int UserId { get; set; }
        public string Allergies { get; set; }
        //[Required]
        //[StringLength(50)]
        public string FirstName { get; set; }

        //[Required]
        //[StringLength(50)]
        public string SecondName { get; set; }

        //[Required]
        //[StringLength(50)]
        public string LastName { get; set; }

        //[Required, EmailAddress]
        public string Email1 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string CellPhone { get; set; }
        public DateTime? Created { get; set; }

        //[StringLength(60, MinimumLength = 3)]
        //[Required]
        public string Title { get; set; }

        //[StringLength(5, MinimumLength = 3)]
        //[Required]
        public string Initials { get; set; }
        public int PersonId { get; set; }

        //[Required]
        public DateTime DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public string PassportNumber { get; set; }
        public string Occupation { get; set; }
        public string IdentityType { get; set; }
        public string Citizenship { get; set; }
        public int? ContactId { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telephone3 { get; set; }
        public string HomeTelephone { get; set; }
        public string WorkTelephone { get; set; }
        public string Fax1 { get; set; }
        public string Fax2 { get; set; }
        public string Email2 { get; set; }
        public int AddressId { get; set; }
    }
}
