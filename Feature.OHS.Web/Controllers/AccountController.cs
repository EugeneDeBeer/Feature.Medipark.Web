using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using Feature.OHS.Web.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult Login([FromBody]LoginViewModel model)
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model == null)
                        return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, new ErrorMessage { message = "Model passed cannot be null" });

                    var response = await _accountHandler.Login(model);

                    if (!response.Success)
                    {
                        return View("Error", new ErrorViewModel() { RequestId = response.Message });
                    }

                    var returnUrl = Convert.ToString(ViewData["ReturnUrl"]);

                    if (!string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    if (response.Success)
                    {
                        var data = JsonConvert.DeserializeObject<APIResponse>(response.Message);

                        if (!data.Success)
                        {
                            return View(model);

                            //ModelState.AddModelError("Credentials", data.Message);
                            //return StatusCode((int) HttpStatusCode.NotFound, data);
                        }
                            
                    }

                    //return RedirectToAction("Dashboard", "Dashboard", response);
                    return RedirectToAction("SuccessLogin", "Account", response);
                }
                catch (Exception ex)
                {
                    return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, new ErrorMessage { message = ex.Message.ToString() });
                }
            }
            else
            {
                return View(model);
            }


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
        [ValidateAntiForgeryToken]
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

                    return RedirectToAction(nameof(Login));
                }
                catch (Exception ex)
                {
                    return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, new ErrorMessage { message = ex.Message.ToString() });
                }
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult SuccessLogin(APIResponse clientInfo)
        {
            return View(new PersonViewModel());
        }

    }
}