using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Interfaces
{
    public interface IQualificationHandler
    {
        QualificationViewModel CreateQualification(QualificationViewModel qualification);

        bool UpdateQualification(StaffPayloadViewModel person);
        QualificationViewModel GetQualificationById(int personId);
    }
}
