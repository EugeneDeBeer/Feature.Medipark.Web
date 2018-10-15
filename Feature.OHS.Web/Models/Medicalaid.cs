using System;
using System.Collections.Generic;

namespace Feature.OHS.Web.Models
{
    public partial class Medicalaid
    {
        public int MedicalAidId { get; set; }
        public string MedicalAidName { get; set; }
        public string MedicalAidPlanName { get; set; }
        public DateTime? MainMemberOb { get; set; }
        public string MedicalAidNumber { get; set; }
        public int? DepedantNo { get; set; }
        public string AuthNo { get; set; }
        public DateTime? AuthDate { get; set; }
        public int? DaysConf { get; set; }
        public decimal? AmountConf { get; set; }
        public int? AccountHolderId { get; set; }
    }
}
