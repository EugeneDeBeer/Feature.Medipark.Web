//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Feature.OHS.Web.Models;
//using Feature.OHS.Web.ViewModels;

//namespace Feature.OHS.Web.Controllers
//{
//    public class PayloadPatientViewModelsController : Controller
//    {


//        public PayloadPatientViewModelsController()
//        {

//        }

//        // GET: PayloadPatientViewModels
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.PayloadPatientViewModel.ToListAsync()); // return a list of persons 
//        }

//        // GET: PayloadPatientViewModels/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var payloadPatientViewModel = await _context.PayloadPatientViewModel
//                .SingleOrDefaultAsync(m => m.PersonId == id);
//            if (payloadPatientViewModel == null)
//            {
//                return NotFound();
//            }

//            return View(payloadPatientViewModel);
//        }

//        // GET: PayloadPatientViewModels/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: PayloadPatientViewModels/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("CreatorType,PatientType_Id,IsActive,PatientId,ReferenceNumber,Allergies,Type,PersonId,FirstName,LastName,DateOfBirth,IdNumber,PassportNumber,CauseOfDeath,DeathDate,CreatorId,MiddleName,Initials,ResAddress1,ResAddress2,ResPostCode,Title,Occupation,Religion,Email,BusAddress,BusPostCode,BusName,HomeTel,WorkTel,ResSurbub,Country,GenderId,DeadTypeId,NokName,NokSurname,NokContact,NokBuildingHome,NokStreetName,NokCountry,NokSurburbTown,NokPostalCode,NokEmail,NokRelationship")] PayloadPatientViewModel payloadPatientViewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(payloadPatientViewModel);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(payloadPatientViewModel);
//        }

//        // GET: PayloadPatientViewModels/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var payloadPatientViewModel = await _context.PayloadPatientViewModel.SingleOrDefaultAsync(m => m.PersonId == id);
//            if (payloadPatientViewModel == null)
//            {
//                return NotFound();
//            }
//            return View(payloadPatientViewModel);
//        }

//        // POST: PayloadPatientViewModels/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("CreatorType,PatientType_Id,IsActive,PatientId,ReferenceNumber,Allergies,Type,PersonId,FirstName,LastName,DateOfBirth,IdNumber,PassportNumber,CauseOfDeath,DeathDate,CreatorId,MiddleName,Initials,ResAddress1,ResAddress2,ResPostCode,Title,Occupation,Religion,Email,BusAddress,BusPostCode,BusName,HomeTel,WorkTel,ResSurbub,Country,GenderId,DeadTypeId,NokName,NokSurname,NokContact,NokBuildingHome,NokStreetName,NokCountry,NokSurburbTown,NokPostalCode,NokEmail,NokRelationship")] PayloadPatientViewModel payloadPatientViewModel)
//        {
//            if (id != payloadPatientViewModel.PersonId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(payloadPatientViewModel);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!PayloadPatientViewModelExists(payloadPatientViewModel.PersonId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(payloadPatientViewModel);
//        }

//        // GET: PayloadPatientViewModels/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var payloadPatientViewModel = await _context.PayloadPatientViewModel
//                .SingleOrDefaultAsync(m => m.PersonId == id);
//            if (payloadPatientViewModel == null)
//            {
//                return NotFound();
//            }

//            return View(payloadPatientViewModel);
//        }

//        // POST: PayloadPatientViewModels/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var payloadPatientViewModel = await _context.PayloadPatientViewModel.SingleOrDefaultAsync(m => m.PersonId == id);
//            _context.PayloadPatientViewModel.Remove(payloadPatientViewModel);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool PayloadPatientViewModelExists(int id)
//        {
//            return _context.PayloadPatientViewModel.Any(e => e.PersonId == id);
//        }
//    }
//}
