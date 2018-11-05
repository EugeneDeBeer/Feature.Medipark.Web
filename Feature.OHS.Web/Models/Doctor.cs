using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feature.OHS.Web.Models
{
    public partial class Doctor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DoctorId { get; set; }
        public string Role { get; set; }
        public int? PersonId { get; set; }
        public string HPCNARegistrationNumber { get; set; }
        public int YearsInPractice { get; set; }
    }
}
