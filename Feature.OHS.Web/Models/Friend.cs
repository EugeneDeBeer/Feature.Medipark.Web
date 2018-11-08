using System;
using System.Collections.Generic;

namespace Feature.OHS.Web.Models
{
    public partial class Friend
    {
        public int FriendId { get; set; }
        public string Tel { get; set; }
        public int PatientId { get; set; }
        public int PersonId { get; set; }
    }
}
