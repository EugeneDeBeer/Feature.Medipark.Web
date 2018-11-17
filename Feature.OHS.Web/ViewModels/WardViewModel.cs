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
       
        public int WardId { get; set; }

        [Display(Name = "Number Of Beds")]
        public int NumberOfBeds { get; set; }

        public int HospitalId { get; set; } // change to get the hospital ID  so make this a string

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Short Name")]
        public string Shortname { get; set; }

        [Display(Name = "Short Code")]
        public string ShortCode { get; set; }

        [Required]
        [Display(Name = "Ward Type")]
        public string Type { get; set; }

        [Display(Name = "Longitude Coordinates")]
        public string Longitute { get; set; }

        [Display(Name = "Latitude Coordinates")]
        public string Latitude { get; set; }

        [Required]
        [Display(Name = "Number of Floors")]
        public int Floor { get; set; }

        [Required]
        [Display(Name = "Ward Size in m2")]
        public int Size { get; set; }

        [Required]
        [Display(Name = "Minimum Number Of Rooms")]
        public int MinRooms { get; set; }

        [Required]
        [Display(Name = "Maximum Number Of Rooms")]
        public int MaxRooms { get; set; }

        //public int RoomOccupancyLevel { get; set; }
        public int FloorPlanId { get; set; }
        public int EventId { get; set; }
        public int StatusId { get; set; }
        public bool Active { get; set; }

        public string EventDescription { get; set; }
        public string EventShortDescription { get; set; }
        public int UserId { get; set; }
    }
}
