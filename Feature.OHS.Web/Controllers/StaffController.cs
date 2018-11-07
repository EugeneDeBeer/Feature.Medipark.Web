using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Feature.OHS.Web.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffHandler _staffHandler;

        public StaffController(IStaffHandler staffHandler)
        {
            _staffHandler = staffHandler;
        }

        public IActionResult CreateDoctor()
        {
            return View("~/Views/Doctors/Create.cshtml", new StaffPayloadViewModel());
        }

        public IActionResult CreateNurse()
        {
            return View("~/Views/Nurses/Create.cshtml", new StaffPayloadViewModel());
        }

        

        public IActionResult EditDoctor(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _staffHandler.GetStaffByIdNumber(id);
            if (user == null)
            {
                return NotFound();
            }
            return View("~/Views/Doctors/Edit.cshtml", user);
        }

        public IActionResult EditNurse(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _staffHandler.GetStaffByIdNumber(id);
            if (user == null)
            {
                return NotFound();
            }
            return View("~/Views/Nurses/Edit.cshtml", user);
        }

        public IActionResult Doctors()
        {
            var members = _staffHandler.Staffs;
            return View("~/Views/Doctors/Index.cshtml", members);
        }
        public IActionResult Nurses()
        {
            var members = _staffHandler.Staffs;
            return View("~/Views/Nurses/Index.cshtml", members);
        }
        //POST:Staff/Edit
        [HttpPost]
        public ActionResult EditStaff(StaffPayloadViewModel staffPayloadViewModel)
        {
            if (ModelState.IsValid)
                try
                {
                    var result = _staffHandler.UpdateStaff(staffPayloadViewModel);
                    return RedirectToAction(nameof(Doctors));
                }
                catch (System.Exception)
                {
                    return View("~/Views/Doctors/Index.cshtml", staffPayloadViewModel);
                }
            else
            {
                ModelState.AddModelError("Error", "Please enter all the required fields");
                return View("Index",staffPayloadViewModel);
            }
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create(StaffPayloadViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _staffHandler.AddStaff(model);

                    return RedirectToAction(nameof(Doctors));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Please enter all the required fields");
                return View(model);
            }
        }
    }
}