using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Feature.OHS.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountHandler _accountHandler;

        public AccountController(IAccountHandler accountHandler)
        {
            _accountHandler = accountHandler;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Registration));
        }

        public IActionResult Registration()
        {
            var model = new PersonViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Registration(PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model == null) return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, new ErrorMessage { message = "Model passed cannot be null" });

                    model.IdNumber = model.IdentityNumber.ToString();

                    var response = await _accountHandler.Register(model);

                    return RedirectToAction(nameof(Registration));
                }
                catch(Exception ex)
                {
                    return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, new ErrorMessage { message = ex.Message.ToString() });
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}