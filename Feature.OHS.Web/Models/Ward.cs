using System;
using System.Collections.Generic;

namespace Feature.OHS.Web.Models
{
    public partial class Ward
    {
        public int WardId { get; set; }
        public string Bed { get; set; }
        public string WardCareNumber { get; set; }
        public string WardClaimNumber { get; set; }
        public string WardName { get; set; }
    }
}
