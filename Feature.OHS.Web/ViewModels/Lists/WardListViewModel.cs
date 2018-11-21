using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels.Lists
{
    public class WardListViewModel
    {
        public int WardId { get; set; }
        //public int NumberOfBeds { get; set; }
        public int HospitalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Shortname { get; set; }
        public string ShortCode { get; set; }
        public string Type { get; set; }
        public int LocationId { get; set; }
        public int Floor { get; set; }
        public int Size { get; set; }
        public int MinRooms { get; set; }
        public int MaxRooms { get; set; }
        //public int RoomOccupancyLevel { get; set; }
        public int FloorPlanId { get; set; }
        public int EventId { get; set; }
        public int StatusId { get; set; }
    }
}
