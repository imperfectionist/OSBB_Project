using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OSBB.Models;
using OSBB_BLL.Models;
using OSBB_BLL.Services;
using OSBB_Identity.Manager;
using OSBB_Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OSBB.Controllers
{
    public class AccountController : Controller
    {
        IGenericService<ApartmentDTO> apartmentService;

        private ApplicationUserManager userManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        private ApplicationSignInManager signInManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationSignInManager>();
            }
        }

        private IAuthenticationManager GetAuthenticationManager()
        {
            var context = Request.GetOwinContext();
            return context.Authentication;
        }

        public AccountController(IGenericService<ApartmentDTO> apartmentService)
        {
            this.apartmentService = apartmentService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login (LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);
            var result = await userManager.CheckPasswordAsync(user, model.Password);

            if (result == true)
            {
                TempData["user"] = user;
                return RedirectToAction("VerifyUser");
            }

            ModelState.AddModelError("", "Невірний логін та/або пароль");
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            var model = new RegisterModel();
            ViewBag.Apartments = new SelectList(apartmentService.GetAll().Where(ap => ap.ApartmentNumber != 1000).OrderBy(a => a.ApartmentNumber).Select(ap => new SelectListItem { Value = ap.ApartmentNumber.ToString(), Text = ap.ApartmentNumber.ToString() }), "Value", "Text");
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register (RegisterModel model)
        {
            ViewBag.Apartments = new SelectList(apartmentService.GetAll().Select(ap => new SelectListItem { Value = ap.ApartmentNumber.ToString(), Text = ap.ApartmentNumber.ToString() }), "Value", "Text");

            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    ApartmentNumber = model.ApartmnentNumber
                };

                ApartmentDTO apartment = apartmentService.FindBy(ap => ap.ApartmentNumber == user.ApartmentNumber).FirstOrDefault();

                if(apartment.Username != null)
                {
                    ModelState.AddModelError("", "Ця квартира вже має зареєстрованого користувача");
                    return View(model);
                }

                var result = await userManager.CreateAsync(user, model.Password);
                

                if (result.Succeeded)
                {
                    apartment.Username = user.UserName;
                    apartmentService.AddOrUpdate(apartment);

                    await userManager.AddToRoleAsync(user.Id, "OSBB_User");

                    TempData["user"] = user;
                    return RedirectToAction("VerifyUser");
                }
                AddErrors(result);
            }


            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult VerifyUser()
        {
            var userFactors = userManager.TwoFactorProviders;
            var factorOptions = userFactors.Select(way => new SelectListItem { Text = way.Key, Value = way.Key }).ToList();
            var model = new VerifyUserModel
            {
                Providers = factorOptions
            };
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode (string provider)
        {
            if (TempData["user"] == null)
            {
                return View("Error");
            }

            var user = (AppUser)TempData.Peek("user");

            var token = await userManager.GenerateTwoFactorTokenAsync(user.Id, provider);
            TempData["userToken"] = token;

            if (provider == "СМС")
            {
                var message = new IdentityMessage
                {
                    Destination = user.PhoneNumber,
                    Body = "Ваш код для входу - " + token
                };
                await userManager.SmsService.SendAsync(message);
            }
            else if (provider == "Електронна пошта")
            {
                await userManager.SendEmailAsync(
                        user.Id,
                        "Підтвердження входу",
                        "Ваш код для підтвердження входу на сайт ОСББ - " + token);
            }

            TempData["user"] = user;

            return View(new VerifyCodeModel { Provider = provider });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeModel model)
        {
            if (TempData["user"] == null || TempData["userToken"] == null)
            {
                return View("Error");
            }

            var token = TempData["userToken"].ToString();
            var user = (AppUser)TempData["user"];

            if(model.Code == token)
            {
                if(model.Provider == "СМС")
                {
                    user.PhoneNumberConfirmed = true;
                }
                else if (model.Provider == "Електронна пошта")
                {
                    user.EmailConfirmed = true;
                }

                var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                GetAuthenticationManager().SignIn(identity);
                
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Невірний код");
            TempData["user"] = user;
            TempData["userToken"] = token;

            return View(model);
        }

        public ActionResult Logoff()
        {
            GetAuthenticationManager().SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        private void AddErrors (IdentityResult result)
        {
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}