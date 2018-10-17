using Feature.OHS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Interfaces
{
    public interface IStaffHandler
    {
        dynamic AddStaff(StaffPayloadViewModel patient);
        dynamic GetStaff(int id, bool includeAllDetails = false);

        dynamic UpdateStaff(StaffPayloadViewModel model);
    }
}
