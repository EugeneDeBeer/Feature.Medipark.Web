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
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public string ShortCode { get; set; }
        //public string Type { get; set; }

        public int LocationId { get; set; }
        //public float Longitude { get; set; }
        //public float Latitude { get; set; }
        public string Type { get; set; }
        public double Rate { get; set; }
        public int RoomId { get; set; }

        public int StatusDescription { get; set; }
        public int EventDescription { get; set; }
    }
}
