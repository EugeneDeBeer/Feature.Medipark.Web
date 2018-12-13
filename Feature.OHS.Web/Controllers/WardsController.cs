using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Feature.OHS.Web.Controllers
{
    public class WardsController : Controller
    {
        private readonly IWard _WardHandler;
        public WardsController(IWard WardHandler)
        {

            _WardHandler = WardHandler;
        }

        // GET: Wards
        public ActionResult List()
        {
            var response = _WardHandler.GetWardList(1);
            if(response == null)
            {
                ViewBag.ErrorMessage = "Failed to create a ward please try again";
                return View();
            }
            return View("List", model: response);
        }

        // GET: Wards/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Wards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wards/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WardViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = _WardHandler.CreateWard(model);

                    if (response == null)
                    {
                        return NotFound();
                    }

                    return RedirectToAction(nameof(List));

                }
                return View();
                // TODO: Add insert logic here
                //  return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Wards/Edit/5
        public ActionResult Edit(int id)
        {
            //var response = _WardHandler.Ward(model);
            return View();
        }

        // POST: Wards/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WardViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = _WardHandler.EditWard(model);

                    if (response == null)
                    {
                        return NotFound();
                    }

                    return RedirectToAction(nameof(List));

                }
                return View();
                // TODO: Add insert logic here
                //  return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Wards/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Wards/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}
