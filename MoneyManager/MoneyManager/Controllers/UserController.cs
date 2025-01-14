﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Core.Models.User;
using MoneyManager.Infrastructure.Data.Entities;

namespace MoneyManager.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new LoginViewModel();

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);


            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (model.UserName.ToLower()=="admin")
                    {
                        return RedirectToAction("Index", "Admin", new { area = "Admin" });
                    }
                    else 
                    {
                        return RedirectToAction("Dashboard", "Home");

                    }
                }

            }

            ModelState.AddModelError("", "Invalid login!");

            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await AddUserToRole(model.Email);
                return RedirectToAction("Login", "User");
            }

            foreach (var err in result.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        private async Task AddUserToRole(string email)
        {
            var roleName = "User";
            var roleExists = await roleManager.RoleExistsAsync(roleName);

            if (!roleExists)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            var user = await userManager.FindByEmailAsync(email);
            var result = await userManager.AddToRoleAsync(user, roleName);

        }

    }
}
