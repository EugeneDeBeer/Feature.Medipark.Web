using System;
using System.Collections.Generic;

namespace Feature.OHS.Web.Models
{
    public partial class Hospital
    {
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public int LocationCode { get; set; }
        public string LocationDescription { get; set; }
        public int AddressId { get; set; }
        public int ContactId { get; set; }
    }
}
