using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Models
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public string ShortCode { get; set; }
        public string Type { get; set; }


        public int MinBeds { get; set; }
        public int MaxBeds { get; set; }

        public int WardId { get; set; }
        public int EventDescription { get; set; }
        public int StatusDescription { get; set; }
    }
}
