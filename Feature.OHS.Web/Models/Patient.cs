using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feature.OHS.Web.Models
{
    public partial class Patient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PatientId { get; set; }
        public string ReferenceNumber { get; set; }
        public string Allergies { get; set; }
        public string Type { get; set; }
        public int PersonId { get; set; }
    }
}
