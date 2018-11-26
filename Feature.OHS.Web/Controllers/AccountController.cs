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

        public IActionResult Registration(string returnUrl)
        {
            var model = new PersonViewModel();

            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                ViewData["ReturnUrl"] = returnUrl;
            }
            else
            {
                ViewData["ReturnUrl"] = string.Empty;
            }

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

                    var returnUrl = Convert.ToString(ViewData["ReturnUrl"]);

                    if (!string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

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