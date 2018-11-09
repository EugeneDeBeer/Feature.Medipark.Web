using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feature.OHS.Web.ViewModels
{
    public class SearchParams
    {
        //  PERSON FILTERS
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string IdNumber { get; set; } = string.Empty;
        public string PassportNumber { get; set; } = string.Empty;
        public string HomeTel { get; set; } = string.Empty;
        public string WorkTel { get; set; } = string.Empty;

        public int PatientId { get; set; }

        //  PAGING FILTERS
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;

        //  SORTING FILTERS
        public string OrderBy { get; set; } = "Asc";
        public string SortBy { get; set; } = "FirstName"; /*"PersonId";*/
        public bool ExactSearch { get; set; } = false;
    }
}
