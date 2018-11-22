using Feature.OHS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Interfaces
{
    public interface  INurseHandler
    {
        DoctorNurseViewModel AddNurse(DoctorNurseViewModel nurseVM);
        DoctorNurseViewModel AddContact(DoctorNurseViewModel doctorVM);
        DoctorNurseViewModel AddAddress(DoctorNurseViewModel doctorVM);
        DoctorNurseViewModel AddPracticeInformation(DoctorNurseViewModel doctorVM);
        DoctorNurseViewModel AddQualification(DoctorNurseViewModel doctorVM);
        DoctorNurseViewModel GetDoctorByIdNumber(string id);
        dynamic UpdateNurse(DoctorNurseViewModel model);
        IEnumerable<DoctorNurseViewModel> Nurses { get; }

        dynamic SearchDoctors(SearchParams condition, bool exactSearch = false);
    }
}
