using System;
using System.Collections;
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
       dynamic AddAddress(PatientViewModel address);
        dynamic AddContact(PatientViewModel patient);
        dynamic AddNextOfKin(PatientViewModel patient);
        IEnumerable<PatientViewModel> Patients { get; }
        PatientViewModel GetPatientByIdNumber(string id);
        dynamic UpdatePatient(PatientViewModel model);
    }
}
