using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class AppointmentViewModel
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string AppointmentShortTypeDescription { get; set; }
        public string AppointmentTypeDescription { get; set; }
        public string EventTypeShortDescription { get; set; }
        public string EventTypeDescription { get; set; }
        public string StatusTypeDescription { get; set; }
        public string StatusTypeShortDescription { get; set; }
        public string PersonTypeShortDescription { get; set; }
        public string PersonTypeDescription { get; set; }
        public string EventDescription { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string Time { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? IsActive { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
