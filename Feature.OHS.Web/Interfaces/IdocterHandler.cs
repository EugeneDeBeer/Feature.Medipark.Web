using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Interfaces
{
    public interface IDocterHandler
    {
        bool IsReferentialDoctor(int id);
        StaffPayloadViewModel CreateDoctor(StaffPayloadViewModel doctor);
        bool UpdateDoctor(StaffPayloadViewModel doctor );
        DoctorViewModel GetDoctorById(int id);
    }
}
