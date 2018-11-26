using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string ContactNumbes { get; set; }
        public string EmailAddress { get; set; }
        public  string Doctor { get; set; }
        public string AppointmentType { get; set; }
        public string  ReminderType { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
    }
}
