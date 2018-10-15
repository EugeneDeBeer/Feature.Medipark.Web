using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feature.OHS.Web.Models
{
    public partial class Nextofkin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int NextOfkinId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PatientId { get; set; }
        public string RelationshipPatientMainMember { get; set; }
        public string Relation { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
    }
}
