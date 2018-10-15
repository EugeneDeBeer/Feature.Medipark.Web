using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.WebInterfaces
{
    public interface IAdmissionHandler
    {
        AdmissionViewModel CreateAdmission(AdmissionViewModel admission);

        bool UpdateAdmission(AdmissionViewModel admission);//, string userId);

        // IEnumerable<Admission> GetAdmissions();

        Admission GetAdmission(int id);

        //  void StallAdmission(Admission admission);
    }
}
