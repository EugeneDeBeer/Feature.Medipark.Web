using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class RoomViewModel
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public string ShortCode { get; set; }
        public string Type { get; set; }
                
      
        public int MinBeds { get; set; }
        public int MaxBeds { get; set; }
        
        public int WardId { get; set; }
        public string EventDescription { get; set; }
        public string StatusDescription { get; set; }
    }
}
