using System;
using System.Collections.Generic;

namespace Feature.OHS.Web.Models
{
    public partial class Discharge
    {
        public int DischargeId { get; set; }
        public DateTime DischargeDate { get; set; }
        public TimeSpan DischargeTume { get; set; }
        public string DischargeReason { get; set; }
        public string BhfpracticeNumber { get; set; }
        public string DischargeLocationCode { get; set; }
        public string DischargeLocationDescription { get; set; }
        public int PatientId { get; set; }
    }
}
