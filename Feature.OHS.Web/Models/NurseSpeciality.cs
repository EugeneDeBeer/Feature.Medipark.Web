using System;
using System.Collections.Generic;

namespace Feature.OHS.Web.Models
{
    public partial class NurseSpeciality
    {
        public int NurseSpecialityId { get; set; }
        public int NurseId { get; set; }
        public int SpecialityId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
