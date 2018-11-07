using Feature.OHS.Web.ViewModels;
using System.Collections.Generic;

namespace Feature.OHS.Web.Interfaces
{
    public interface IStaffHandler
    {
        dynamic AddStaff(StaffPayloadViewModel payload);

        dynamic GetStaff(int id, bool includeAllDetails = false);

        dynamic GetStaffByIdNumber(string id);

        IEnumerable<StaffPayloadViewModel> Staffs { get; }

        dynamic UpdateStaff(StaffPayloadViewModel model);
    }
}