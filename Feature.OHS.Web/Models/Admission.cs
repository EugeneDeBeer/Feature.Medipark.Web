using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feature.OHS.Web.Models
{
    public partial class Admission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AdmisssionId { get; set; }
        public int? HospitalId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int? LocationCode { get; set; }
        public string LocationDescription { get; set; }
        public sbyte? InpatientoRoutPatient { get; set; }
        public string DietRequirment { get; set; }
        public string AdmittedByUsername { get; set; }
        public sbyte? InjuredOnJob { get; set; }
        public DateTime? DateInjury { get; set; }
        public int PatientId { get; set; }
        public int WardId { get; set; }
    }
}
