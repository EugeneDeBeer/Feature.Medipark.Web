using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.ViewModels;
using Feature.OHS.Web.ViewModels.Response;

namespace Feature.OHS.Web.Interfaces
{
    public interface IPatientHandler
    {
        PatientViewModel AddPatient(PatientViewModel patient);
        PatientViewModel AddAddress(PatientViewModel patient);
        PatientViewModel AddContact(PatientViewModel patient);
        PatientViewModel AddNextOfKin(PatientViewModel patient);
        dynamic GetPatient(int id, bool includeAllDetails = false);
        dynamic GetPatients();
        dynamic UpdatePatient(PatientViewModel model);
    }
}
