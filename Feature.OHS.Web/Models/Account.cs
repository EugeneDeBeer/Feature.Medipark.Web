using System;
using System.Collections.Generic;

namespace Feature.OHS.Web.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public decimal? Balance { get; set; }
        public decimal? BillingTotal { get; set; }
        public int? DaysOutstanding { get; set; }
        public sbyte? IsReleased { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public TimeSpan? ReleasedTime { get; set; }
        public string RealeasedByUsername { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public string BillingCode { get; set; }
        public string BillingCodeDescription { get; set; }
        public int? AccountHolderId { get; set; }
        public int? PatientId { get; set; }
    }
}
