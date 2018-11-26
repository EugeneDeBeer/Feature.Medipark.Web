using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels.Admin
{
    public class UserViewModel
    {
        //  USER
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Admin { get; set; }
        public string EmailAddress { get; set; }

        //  Person Details
        public byte[] ProfileImage { get; set; } = null;

        //  USER ROLES
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
    }
}
