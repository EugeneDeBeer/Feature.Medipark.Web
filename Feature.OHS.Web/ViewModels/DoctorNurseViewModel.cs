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
        public int PersonDetailsId { get; set; }
        public string HpcnaregistrationNumber { get; set; }
        public int NumberOfYearsInPractice { get; set; }
        public string RegistrationNumber { get; set; }
        public int UserId { get; set; }
        public string Allergies { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Email1 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string CellPhone { get; set; }
        public DateTime? Created { get; set; }
        public int DoctorId { get; set; }
        public int? QualificationId { get; set; }
        public string Title { get; set; }
        public string Initials { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public string PassportNumber { get; set; }
        public string Occupation { get; set; }
        public string IdentityType { get; set; }
        public string Citizenship { get; set; }
        public int ContactId { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telephone3 { get; set; }
        public string HomeTelephone { get; set; }
        public string WorkTelephone { get; set; }
        public string Fax1 { get; set; }
        public string Fax2 { get; set; }
        public string Email2 { get; set; }
        public string Name { get; set; }
        public string Institution { get; set; }
        public int AddressId { get; set; }
    }
}
