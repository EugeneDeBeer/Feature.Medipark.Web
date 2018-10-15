using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class StaffPayloadViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public string PassportNumber { get; set; }
        public string CauseOfDeath { get; set; }
        public DateTime? DeathDate { get; set; }
        public int? CreatorId { get; set; }
        public string MiddleName { get; set; }
        public string Initials { get; set; }
        public string ResAddress1 { get; set; }
        public string ResAddress2 { get; set; }
        public string ResPostCode { get; set; }
        public string Title { get; set; }
        public string Occupation { get; set; }
        public string Religion { get; set; }
        public string Email { get; set; }
        public string BusAddress { get; set; }
        public int QualificationId { get; set; }
        public string NameOfDegree { get; set; }
        public string Institution { get; set; }
        public string YearObtained { get; set; }
        public string BusPostCode { get; set; }
        public string Type { get; set; }
        public string BusName { get; set; }
        public string HomeTel { get; set; }
        public string WorkTel { get; set; }
        public string ResSurbub { get; set; }
        public string Country { get; set; }
        public string GenderId { get; set; }
        public int DeadTypeId { get; set; }
        public string Ethnicity { get; set; }
        public string IdentityType { get; set; }
        public string MaritalStatus { get; set; }
        public int NurseId { get; set; }
        public string PracticeNumber { get; set; }
        public int DoctorId { get; set; }
        public string Role { get; set; }
        public int PersonId { get; set; }
        public string HPCNARegistrationNumber { get; set; }
        public int YearsInPractice { get; set; }
        //Contact
        public string Telephone1 { get; set; }

        public string Telephone2 { get; set; }
        public string Telephone3 { get; set; }
        public string HomeTelephone { get; set; }
        public string WorkTelephone { get; set; }
        public string CellPhone { get; set; }
        public string Fax1 { get; set; }
        public string Fax2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }

        //Address
        public int AddressId { get; set; }

        public int AddressTypeId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public int SuburbId { get; set; }
        public int CityId { get; set; }
        public int PostCodeId { get; set; }
    }
}
