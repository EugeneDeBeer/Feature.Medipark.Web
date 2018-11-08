using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class FriendViewModel
    {
        public int FriendId { get; set; }
        //public DateTime DateCreated { get; set; }
        public string Tel { get; set; }

        //public DateTime LastModifiedDate { get; set; }
        //public int LastModifiedBy { get; set; }

        public int PatientId { get; set; }
        public int PersonId { get; set; }

    }
}
