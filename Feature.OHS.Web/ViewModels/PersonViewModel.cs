using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class PersonViewModel
    {
        public int UserId { get; set; }
        public int DoctorId { get; set; }
        [Required]
        public string Title { get; set; }
      
        [Required]
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 10 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        //public bool ExpirePassword { get; set; }
        //public bool ResetPassword { get; set; }
        public bool IsDoctor { get; set; }
        public int PersonId { get; set; }

        [Required(ErrorMessage="Please enter your email address as your {0}")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; }

        [Required]
        public long IdentityNumber { get; set; }

        //[Required]
        public string IdNumber { get; set; }

        //  Catered for at controller level
        public string EventDescription { get; set; }
        public string EventTypeShortDescription { get; set; }
        public string EventTypeDescription { get; set; }
        public string StatusTypeShortDescription { get; set; }
        public string StatusTypeDescription { get; set; }
        public string PersonTypeShortDescription { get; set; }
        public string PersonTypeDescription { get; set; }


        [Display(Name = "Work Telephone")]
        public string Telephone2 { get; set; }

        [Display(Name = "Cell Number <span>*</span>")]
        public string CellPhone { get; set; }

        public int? UserRoleId { get; set; }
        public string RoleName { get; set; }    //  With help reduce API requests when looking up role information

        //public DateTime? DateOfBirth { get; set; }

        //public string PassportNumber { get; set; }
        //public string Initials { get; set; }
        //public string IdentityType { get; set; }
        //public string Citizenship { get; set; }
        //public int PersonDetailsId { get; set; }
        //public int? EventId { get; set; }        
        //public string EventDescription { get; set; }
        //public sbyte? IsActive { get; set; }
    }
}
