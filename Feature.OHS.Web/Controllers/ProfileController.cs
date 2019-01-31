using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Feature.OHS.Web.Controllers
{
    public class ProfileController : Controller
    {
  
        public IActionResult Summary(PatientPayloadViewModel patient)
        {
            return View(patient ?? new PatientPayloadViewModel());
        }
    }
}
