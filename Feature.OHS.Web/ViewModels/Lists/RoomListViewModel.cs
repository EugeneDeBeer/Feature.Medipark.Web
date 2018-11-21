using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels.Lists
{
    public class RoomListViewModel
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public string ShortCode { get; set; }
        public string Type { get; set; }

        public string LocationId { get; set; }
        //public float Longitude { get; set; }
        //public float Latitude { get; set; }
        //public int Floor { get; set; }
        //public int Size { get; set; }
        //public int NumberOfBeds { get; set; }
        public int MinBeds { get; set; }
        public int MaxBeds { get; set; }
        // public int FloorPlanId { get; set; }

        public int WardId { get; set; }
        public int EventId { get; set; }
        public int StatusId { get; set; }
    }
}
