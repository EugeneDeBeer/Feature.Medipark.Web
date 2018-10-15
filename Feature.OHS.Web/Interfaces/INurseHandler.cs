using Feature.OHS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Interfaces
{
    public interface INurseHandler
    {
       StaffPayloadViewModel CreateNurse(StaffPayloadViewModel nurse);
       NurseViewModel GetNurseById(int id);
        bool UpdateNurse(StaffPayloadViewModel nurse);
    }
}
