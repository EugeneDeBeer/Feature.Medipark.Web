using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Feature.OHS.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Registration));
        }

        public IActionResult Registration()
        {
            var model = new PatientPayloadViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Registration(PatientPayloadViewModel model)
        {
            return RedirectToAction(nameof(Registration));
        }
    }
}