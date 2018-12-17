using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Models
{
    public partial class UserRole
    {
        public int UserRoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedById { get; set; }
    }
}
