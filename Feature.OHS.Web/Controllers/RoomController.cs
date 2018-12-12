using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Feature.OHS.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IWard _WardHandler;
        public RoomController(IWard WardHandler)
        {
            _WardHandler = WardHandler;
        }

        public ActionResult Index() =>
            //var response = _WardHandler.GetWardList(1);
            //if (response.Count < 1)
            //{
            //    return View();
            //}
            //return View("List", model: response);
            View();

        public IActionResult Create()
        {
            var response = _WardHandler.GetWardList(1);
            ViewBag.Wards = response;
            return View();
        }

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

        public IActionResult Edit()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Details()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}