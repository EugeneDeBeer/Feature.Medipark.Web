using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Feature.OHS.Web.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorHandler _doctorHandler;
        public DoctorsController(IDoctorHandler doctorHandler)
        {
            _doctorHandler = doctorHandler;
        }

        public ActionResult Create()
        {
            return View("~/Views/Doctors/Create.cshtml", new DoctorNurseViewModel());
        }


        [HttpPost]
        public ActionResult CreateDoctor(DoctorNurseViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.UserId = 1;
                    var result = _doctorHandler.AddDoctor(model);
                    PersonId.Id = result.PersonId;
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


        [HttpPost]
        public ActionResult CreateContactAddress(DoctorNurseViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.PersonId = PersonId.Id;
                    var contact = _doctorHandler.AddContact(model);
                    var address = _doctorHandler.AddAddress(model);
                    
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
        [HttpPost]
        public ActionResult EditDoctor(DoctorNurseViewModel patientViewModel)
        {
            var result = _doctorHandler.UpdateDoctor(patientViewModel);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditDoctor(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _doctorHandler.GetDoctorByIdNumber(id);
            if (user == null)
            {
                return NotFound();
            }
            return View("~/Views/Doctors/Edit.cshtml", user);
        }
        public IActionResult Doctors()
        {
            var members = _doctorHandler.Doctors;
            return View("~/Views/Doctors/Index.cshtml", members);
        }
        [HttpPost]
        public ActionResult PracticeInfo(DoctorNurseViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.PersonId = PersonId.Id;
                    var practiceInfo = _doctorHandler.AddPracticeInformation(model);

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

        [HttpPost]
        public ActionResult CreateQualification(DoctorNurseViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.PersonId = PersonId.Id;
                    var practiceInfo = _doctorHandler.AddQualification(model);
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
        // GET: Doctors
        public IActionResult Index()
        {
            return View();
            //return View("~/Views/Doctors/Index.cshtml");
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Doctors/Create
        

        // POST: Doctors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpGet("AdvanceSearch")]
        public async Task<IActionResult> Get(SearchParams searchParams)
        {
            try
            {
                if (searchParams == null) return StatusCode((int)System.Net.HttpStatusCode.NotFound);

                //var result = await _patientHandler.SearchPatients(searchParams, searchParams.ExactSearch);
                var result = _doctorHandler.SearchDoctors(searchParams, searchParams.ExactSearch);
                if (result != null)
                {
                    //var model = _pagingHandler.GetPagingInfo(new SearchParams(), result);

                    //Response.Headers.Add("X-Pagination", model.GetHeader().ToJson());

                    return StatusCode((int)System.Net.HttpStatusCode.OK, JsonConvert.SerializeObject(result));
                }
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, new ErrorMessage { message = e.Message.ToString() });
            }
        }
    }
}