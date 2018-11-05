using System;
using System.Collections.Generic;

namespace Feature.OHS.Web.Models
{
    public partial class Doctorspeciality
    {
        public int DoctorSpecialityId { get; set; }
        public int DoctorId { get; set; }
        public int SpecalityId { get; set; }
    }
}
