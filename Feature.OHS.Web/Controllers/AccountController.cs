using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Feature.OHS.Search.Modela;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using Feature.OHS.Web.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mail;
using Feature.OHS.Web.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Feature.OHS.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountHandler _accountHandler;
        private string systemEmailAddress = "no-reply@ohs.com";

        public AccountController(IAccountHandler accountHandler)
        {
            _accountHandler = accountHandler;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login(string returnUrl = "")
        {
            return View(new LoginViewModel(){ReturnUrl = returnUrl });
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

                    if (response.Success)
                    {
                        var data = JsonConvert.DeserializeObject<APIResponse>(response.Message);

                        if (!data.Success)
                        {
                            return View(model);

                            //ModelState.AddModelError("Credentials", data.Message);
                            //return StatusCode((int) HttpStatusCode.NotFound, data);
                        }

                        var responseData = JsonConvert.DeserializeObject<PersonViewModel>(data.Message);

                        if (responseData != null && responseData.UserRoleId > 0)
                        {
                            // Requires: using Microsoft.AspNetCore.Http;
                            //if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Username")) && !string.IsNullOrEmpty(HttpContext.Session.GetString("Password")))
                            //{
                            //    //  Remove old Session
                            //    HttpContext.Session.Remove("Username");
                            //    HttpContext.Session.Remove("Password");                                
                            //}

                            //  Set Session based on the current logged in person
                            //HttpContext.Session.SetString("Username", model.UserName);
                            //HttpContext.Session.SetString("Password", model.Password);

                            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
                            {
                                //  Remove old Session
                                HttpContext.Session.Remove("User");
                            }

                            //  Set Session based on the current logged in person
                            HttpContext.Session.SetObject("User", responseData);

                            
                            if (!string.IsNullOrWhiteSpace(model.ReturnUrl))
                            {
                                return Redirect(model.ReturnUrl);
                                //return Redirect(model.ReturnUrl + "?returnUrl=" + model.ReturnUrl);
                            }

                            //  Lands user to the calendar view based on Roles

                            if (responseData.UserRoleId == 3)    
                            {
                                //return RedirectToAction("Index", "Appointment", response);
                                return RedirectToAction("Index", "Appointment");
                            }
                            else if (responseData.UserRoleId == 2)
                            {
                                return RedirectToAction("Index", "Appointment");
                            }
                            else
                            {
                                return RedirectToAction("Dashboard", "Dashboard");
                            }
                        }
                    }

                    return RedirectToAction("Login", "Account");
                    //return RedirectToAction("Dashboard", "Dashboard", response);
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            //  Clear session here

            // Requires: using Microsoft.AspNetCore.Http;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                HttpContext.Session.Remove("User");
            }
            //if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Username")) && !string.IsNullOrEmpty(HttpContext.Session.GetString("Password")))
            //{
            //    HttpContext.Session.Remove("Username");
            //    HttpContext.Session.Remove("Password");               
            //}

            return RedirectToAction(nameof(Login), "Account");
        }

        public IActionResult SuccessLogin(APIResponse clientInfo)
        {
            var temp = JsonConvert.DeserializeObject<APIResponse>(clientInfo.Message);

            var personInfo = JsonConvert.DeserializeObject<PersonViewModel>(temp.Message);

            if(personInfo != null)
                return View(personInfo);

            return View(new PersonViewModel());
        }


        public async Task<IActionResult> Registration(string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("User")))
            {
                return RedirectToAction("Login", nameof(Account), new { returnUrl = Url.Action(nameof(AccountController.Registration), "Account") });
            }

            var user = HttpContext.Session.GetObject<PersonViewModel>("User");

            if (user == null)
                return RedirectToAction("Login", nameof(Account), new { returnUrl = Url.Action(nameof(AccountController.Registration), "Account") });

            if (user.UserRoleId != 1)
                return RedirectToAction("Index", "Appointment", new { returnUrl = Url.Action(nameof(AppointmentController.Index), "Appointment") });

            var model = new PersonViewModel();
            
            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                ViewData["ReturnUrl"] = returnUrl;
            }
            else
            {
                ViewData["ReturnUrl"] = string.Empty;
            }

            var results = await _accountHandler.GetAllRoles();

            if (results != null)
            {
                var roles = JsonConvert.DeserializeObject<List<UserRole>>(results.Message);

                if (roles.Any())
                {
                    ViewData["UserRoles"] = new SelectList(roles.Select(u => new
                    {
                        u.UserRoleId,
                        u.RoleName
                    }), "UserRoleId", "RoleName");
                }                
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
                    model.UserId = HttpContext.Session.GetObject<PersonViewModel>("User").UserId;   //  Gets the UserId of the currently logged in user
                    model.PersonId = HttpContext.Session.GetObject<PersonViewModel>("User").PersonId;

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


        /** START FORGOT PASSWORD
         */

        /// <summary>
        /// Step 1: Render the forgot password form
        /// Takes in the email for which the password should
        /// </summary>
        /// <param name="returnURL"></param>
        /// <returns>view</returns>
        public IActionResult ForgotPassword(string returnURL)
        {
            var model = new ForgotPasswordViewModel();

            if (!string.IsNullOrWhiteSpace(returnURL))
            {
                ViewData["ReturnUrl"] = returnURL;
            }
            else
            {
                ViewData["ReturnUrl"] = string.Empty;
            }

            return View(model);
        }

        /// <summary>
        /// Step 2: Inject the submitted forgot password form
        /// details. 
        /// 1. Check that the email exists, 
        /// 2. Generate a token
        /// 3. Persist the token
        /// 4. Email link to requested user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _accountHandler.FindUserByEmail(model);
                if (user == null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                //string code = GeneratePasswordResetToken();
                string code = _accountHandler.GeneratePasswordResetToken();
                //var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.StatusCode, code = code });

                var callbackUrl = Url.Action(nameof(ResetPassword), "Account", new { userId = user.UserId, code = code }, protocol: HttpContext.Request.Scheme);


                // update the user table with code
                var pwdResetToken = new UpdatePasswordResetTokenModel();
                pwdResetToken.UserId = user.UserId;
                pwdResetToken.ResetToken = code;

                _accountHandler.SetUserPasswordResetToken(pwdResetToken);

                // email the user
                //SendEmailAsync(model.Email, systemEmailAddress, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                var mailVM = new MailViewModel()
                {
                    MailContent = "Please reset your password by clicking < a href =\"" + callbackUrl + "\">here</a>",
                    MailDestination = model.Email,
                    MailSource = systemEmailAddress,
                    MailSubject = "Reset Password",
                    SmtpServer = "smtp.gmail.com",
                    MailTitle = "Omeyah Health System",
                    SmtpPortNumber = 587
                };
                _accountHandler.SendEmail(mailVM);

                TempData["ViewBagLink"] = callbackUrl;
                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        public ActionResult ForgotPasswordConfirmation()
        {
            ViewBag.Link = TempData["ViewBagLink"];
            return View();
        }

        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View(new ResetPasswordViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ForgotPasswordViewModel fpvm = new ForgotPasswordViewModel();
            fpvm.Email = model.Email;

            var user = await _accountHandler.FindUserByEmail(fpvm);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }

            var result = await _accountHandler.ResetPasswordAsync(model);
            if (result != null)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }

            return View();
        }

        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

      


    }
}