using Feature.OHS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Interfaces
{
    public interface  INurseHandler
    {
        //DoctorNurseViewModel AddNurse(DoctorNurseViewModel patient);

        dynamic GetNurse(int id);
        dynamic GetNurses();
    }
}
