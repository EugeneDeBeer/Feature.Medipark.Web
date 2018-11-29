using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feature.OHS.Search.Modela
{
    public partial class PersonDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PersonDetailsId { get; set; }

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
        public int? ReligionId { get; set; }
        public string IdentityType { get; set; }
        public int? MaidenName { get; set; }
        public int? MaritalStatusId { get; set; }
        public string Citizenship { get; set; }
        public int? NationalityId { get; set; }

        public int? EventId { get; set; }
        public int PersonId { get; set; }
        public int? StatusId { get; set; }

        public byte[] ProfileImage { get; set; } = null;

        //public string CauseOfDeath { get; set; }
        //public DateTime? DeathDate { get; set; }

        //public Address Address { get; set; }
        //public Contact Contact { get; set; }
        //public Country Country { get; set; }

        //public int? ContactId { get; set; }
        //public int? AddressId { get; set; }



        //public string Type { get; set; }


        //public int? CreatedById { get; set; }
        //public DateTime? CreatedOn { get; set; }
        //public DateTime? ModifiedOn { get; set; }
        //public int? ModifiedById { get; set; }
        //[NotMapped]
        //public User CreatedBy { get; set; }
        //[NotMapped]
        //public User ModifiedBy { get; set; }





        //public Ethnicity Ethnicity { get; set; }
        //public Maritalstatus MaritalStatus { get; set; }
        //public Country Nationality { get; set; }
        //public Religion Religion { get; set; }
    }
}
