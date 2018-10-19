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

        public IActionResult EditNurse(int? nurseId)
        {
            //var result =
            return View("~/Views/Nurses/Edit.cshtml", new StaffPayloadViewModel());
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

        public IActionResult Index()
        {
            var members = _staffHandler.Staffs;
            return View("~/Views/Doctors/Index.cshtml", members);
        }

        //POST:Staff/Edit
        [HttpPost]
        public ActionResult EditStaff([Bind("PersonId,FirstName,LastName,DateOfBirth,IdNumber,PassportNumber,MiddleName,Initials,Title,Religion,BusAddress, QualificationId,"+
            "NameOfDegree,Institution,YearObtained,BusPostCode,Type,Country,GenderId,DeadTypeId,Ethnicity,IdentityType,MaritalStatus,NurseId,PracticeNumber,"+
            "Role,HPCNARegistrationNumber,YearsInPractice") ] StaffPayloadViewModel staffPayloadViewModel)
        {
            if (ModelState.IsValid)
                try
                {
                    var result = _staffHandler.UpdateStaff(staffPayloadViewModel);
                    return RedirectToAction(nameof(Index));
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

                    return RedirectToAction(nameof(Index));
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