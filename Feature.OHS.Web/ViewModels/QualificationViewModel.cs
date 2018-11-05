using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class QualificationViewModel
    {
        public int QualificationId { get; set; }
        public string NameOfDegree { get; set; }
        public string Institution { get; set; }
        public string YearObtained { get; set; }
        public int PersonId { get; set; }
    }
}
