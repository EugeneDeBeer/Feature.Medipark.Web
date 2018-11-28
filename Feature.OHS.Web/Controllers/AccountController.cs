using System;

using System.Threading.Tasks;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Models;
using Feature.OHS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

using Microsoft.AspNetCore.Authorization;

namespace Feature.OHS.Web.Controllers
{       
    
    [Authorize]
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

        public IActionResult Login()
        {
            return View();
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
                        return View("Error", new ErrorViewModel(){RequestId = "Model cannot be null" });
                    }

                    var returnUrl = Convert.ToString(ViewData["ReturnUrl"]);

                    if (!string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Dashboard", "Dashboard", response);
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
        /// Step 2: Injest the submitted forgot password form
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

                string code     = GeneratePasswordResetToken();
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.UserId, code = code });

                // update the user table with code
                var pwdResetToken           = new UpdatePasswordResetTokenModel();
                pwdResetToken.UserId        = user.UserId;
                pwdResetToken.ResetToken    = code;

                _accountHandler.SetUserPasswordResetToken(pwdResetToken);

                // email the user
                SendEmailAsync(model.Email, systemEmailAddress, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
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
            return code == null ? View("Error") : View();
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

        private String GeneratePasswordResetToken()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }

        private async void SendEmailAsync(string to, string from, string subject, string body)
        {
            MailMessage mail = new MailMessage(from, to);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            mail.Subject = subject;
            mail.Body = body;
            client.Send(mail);

            return;
        }
    }
}