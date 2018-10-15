using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;

namespace Feature.OHS.Web.Interfaces
{
    public interface INextOfKinHandler
    {
        PatientPayloadViewModel CreateNextOfKin(PatientPayloadViewModel nextOfKin, int id);

        bool UpdateNextOfKin(PatientPayloadViewModel nextOfKin);

        
        NextOfKinViewModel GetNextOfKinByPatientId(int PatientId);
    }
}