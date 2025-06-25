using Application.Services.Department;
using Application.Services.Email;
using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using System.Security.Cryptography.X509Certificates;

namespace Presentation.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly UserManager<MyUser> _userManager;
        private readonly SignInManager<MyUser> _signInManager;
        private readonly IEmailService _emailService;

        public AccountController(UserManager<MyUser> userManager, SignInManager<MyUser> signInManager, IEmailService emailService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailService = emailService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new MyUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var confirmationLink = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { userId = user.Id, token = token },
                        Request.Scheme);

                   
                    var body = $"<p>Thanks for registering!</p><p>Click <a href='{confirmationLink}'>here</a> to confirm your email.</p>";
                    await _emailService.SendEmailAsync(user.Email, "Confirm your email", body);
                    return RedirectToAction("Index", "Home");

                   


                    //var result = await _userManager.CreateAsync(user, model.Password);

                    //if (result.Succeeded)
                    //{
                    //    await _signInManager.SignInAsync(user, isPersistent: false);
                    //    return RedirectToAction("Index", "Home");
                    //}

                    //    var errorMessages = string.Join("<br>", result.Errors.Select(e => e.Description));
                    //    SetFlashMessage(errorMessages, "error");
                    //    return View(model);
                    //}
                    //return View(model);
                }
               
            }
            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            if (result.IsLockedOut)
            {
                SetFlashMessage("Account Locked!, Try again Later", "error");
                return View(model);
            }

            SetFlashMessage("Invalid login attempt!", "error");

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> EditProfile(CreateEmployeeViewModel emp)
        {
            if (!ModelState.IsValid) return View(emp);
            var user = await _userManager.GetUserAsync(User);
            var model = new EditProfileViewModel
            {
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Age = user.Age,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model, CreateEmployeeViewModel emp)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.GetUserAsync(User);


            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Age = model.Age;
            user.Address = model.Address;
            user.PhoneNumber = model.PhoneNumber;
            user.Gender = model.Gender;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                emp.FirstName = model.FirstName;
                emp.LastName = model.LastName;

                SetFlashMessage( "Profile updated successfully!", "success");
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login");

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (result.Succeeded)
            {
                SetFlashMessage("Password updated successfully!", "success"); ;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                SetFlashMessage("Wrong password!", "error"); 
            }
                return View(model);

        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        public async Task<IActionResult> SendTestEmail()
        {
            await _emailService.SendEmailAsync("Sadad@gmail.comexample.com", "Hello", "<p>This is a test email.</p>");
            return Content("Email sent!");
        }

    }
}

