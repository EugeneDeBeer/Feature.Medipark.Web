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
        PatientPayloadViewModel AddPatient(PatientPayloadViewModel patient);
       dynamic AddAddress(PatientPayloadViewModel address);
        dynamic AddContact(PatientPayloadViewModel patient);
        dynamic AddNextOfKin(PatientPayloadViewModel patient);
        IEnumerable<PatientPayloadViewModel> Patients { get; }
      PatientPayloadViewModel GetPatientByIdNumber(string id);
        dynamic UpdatePatient(PatientPayloadViewModel model);

        dynamic SearchPatients(SearchParams condition, bool exactSearch = false);
    }
}
