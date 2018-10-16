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
        dynamic AddPatient(PatientPayloadViewModel patient);
        dynamic GetPatient(int id, bool includeAllDetails = false);

        dynamic UpdatePatient(PatientPayloadViewModel model);
    }
}
