using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class AdmissionViewModel
    {
        //  ADMISSION
        public int AdmisssionId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        //public DateTime Date { get; set; }
        //public DateTime Time { get; set; }
        public sbyte? InpatientoRoutPatient { get; set; }
        public string DietRequirements { get; set; }
        public string AdmittedByFullName { get; set; }
        public sbyte? InjuredOnJob { get; set; }
        public DateTime? DateInjury { get; set; }

        [Required]
        public int PatientId { get; set; }
        public int? BedId { get; set; }
        public int? EventId { get; set; }
        public int? StatusId { get; set; }

        //  PERSON DETAILS
        public string Title { get; set; }
        public string Initials { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public string PassportNumber { get; set; }
        public int? GenderId { get; set; }
        public string Occupation { get; set; }
        public int? CountryId { get; set; }
        public int? EthnicityId { get; set; }
        public string IdentityType { get; set; }
        public string MaidenName { get; set; }
        public int? MaritalStatusId { get; set; }
        public string Citizenship { get; set; }
        public int? NationalityId { get; set; }


        //  Contact
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

        //  Address
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }

        //  Medical Aid
        public int MedicalAidId { get; set; }
        public string MedicalAidName { get; set; }
        public string MedicalAidPlanName { get; set; }
        public DateTime? MainMemberOb { get; set; }
        public string MedicalAidNumber { get; set; }
        public int? DepedantNo { get; set; }
        public string AuthNo { get; set; }
        public DateTime? AuthDate { get; set; }
        public int? DaysConf { get; set; }
        public decimal? AmountConf { get; set; }
        public int? AccountHolderId { get; set; }
    }
}
