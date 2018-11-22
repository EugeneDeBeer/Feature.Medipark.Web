using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class WardViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int WardId { get; set; }
        public int NumberOfBeds { get; set; }
        public int HospitalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Shortname { get; set; }
        public string ShortCode { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int Location { get; set; }
        public float Longitute { get; set; }
        public float Latitude { get; set; }
        public int Floor { get; set; }
        public int Size { get; set; }
        public int MinNumberOfBeds { get; set; }
        public int MaxNumberOfBeds { get; set; }
        public int RoomOccupancyLevel { get; set; }
        public string WardLayout { get; set; }
    }
}
