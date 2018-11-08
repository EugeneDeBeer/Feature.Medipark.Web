using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feature.OHS.Web.Models
{
    public partial class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public int AddressId { get; set; }
        public int AddressTypeId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public int SuburbId { get; set; }
        public int CityId { get; set; }
        public int PostCodeId { get; set; }
        public int PersonId { get; set; }

    }
}
