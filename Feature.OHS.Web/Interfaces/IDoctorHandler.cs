using Feature.OHS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Interfaces
{
    public interface IDoctorHandler 
    {
        DoctorNurseViewModel AddDoctor(DoctorNurseViewModel doctorVM);
        DoctorNurseViewModel AddContact(DoctorNurseViewModel doctorVM);
        DoctorNurseViewModel AddAddress(DoctorNurseViewModel doctorVM);
        DoctorNurseViewModel AddPracticeInformation(DoctorNurseViewModel doctorVM);
        DoctorNurseViewModel AddQualification(DoctorNurseViewModel doctorVM);
        DoctorNurseViewModel GetDoctorByIdNumber(string id);
        dynamic UpdateDoctor(DoctorNurseViewModel model);
        IEnumerable<DoctorNurseViewModel> Doctors { get;  }

        dynamic SearchDoctors(SearchParams condition, bool exactSearch = false);
    }
}
