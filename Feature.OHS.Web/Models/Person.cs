using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feature.OHS.Web.Models
{
    public partial class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
 
        public int PersonId { get; set; }
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

      
    }
}
