using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class BedViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BedId { get; set; }
        public string BedName { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public string ShortCode { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int Floor { get; set; }
        public int Size { get; set; }
        public string OccupancyStatus { get; set; }
        public int PersonId { get; set; }
        public string GenderOfOccupant { get; set; }
        public DateTime AllocationDateTime { get; set; }
        public int AllocatedBy { get; set; }
        public string BedType { get; set; }
        public string BedRate { get; set; }
    }
}
