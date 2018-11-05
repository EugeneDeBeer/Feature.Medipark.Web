using System;
using System.Collections.Generic;

namespace Feature.OHS.Web.Models
{
    public partial class Treatment
    {
        public int TreatmentId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DateInjury { get; set; }
        public int? PatientId { get; set; }
    }
}
