using Feature.OHS.Search.Modela;
using Feature.OHS.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class AppointmentViewModel
    {
      
        public int UserId { get; set; }
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int PersonId { get; set; }

        //[Required]
        public int DoctorId { get; set; }
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

        
        [StringLength(13, ErrorMessage = "Id Number must be  13 digits", MinimumLength =13)]
        [DataType(DataType.Text)]
        [Required]
        public string IdNumber { get; set; }

        public string SearchIdNumber { get; set; }
        public string PatientIdNumber { get; set; }

        [Required]
        public string Time { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? IsActive { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }

        //[Required]
        public string Title { get; set; }
        public string CellPhone { get; set; }
        public string Email1 { get; set; }
        public List<string> Theatre { get; set; }
        public int RoomId { get; set; }
        public string DoctorName { get; set; }
       
    }
}
