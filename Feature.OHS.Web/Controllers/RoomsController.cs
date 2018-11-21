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
    
    public class RoomsController : Controller
    {
        private readonly IWard _WardHandler;
        public RoomsController(IWard WardHandler)
        {
            _WardHandler = WardHandler;
        }

        // GET: Wards
        public ActionResult Index()
        {
            //var response = _WardHandler.GetWardList(1);
            //if (response.Count < 1)
            //{
            //    return View();
            //}
            //return View("List", model: response);
            return View();
        }

        // GET: Wards/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Wards/Create
        public ActionResult Create()
        {
            var response = _WardHandler.GetWardList(1);
            ViewBag.Wards = response;
            return View();
        }

        // POST: Wards/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = _WardHandler.CreateRoom(model);
                    
                    if (response == null)
                    {
                        return NotFound();
                    }

                    return RedirectToAction(nameof(Index));

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
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction(nameof(Index));
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

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
