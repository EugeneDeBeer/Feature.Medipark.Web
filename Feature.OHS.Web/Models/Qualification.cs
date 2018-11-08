using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feature.OHS.Web.Models
{
    public partial class Qualification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int QualificationId { get; set; }
        public string NameOfDegree { get; set; }
        public string Institution { get; set; }
        public string YearObtained { get; set; }
        public int PersonId { get; set; }

    
    }
}
