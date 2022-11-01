using expanse_Tracker.Models;
using expanse_Tracker.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace expanse_Tracker.Controllers
{
    public class AccountController : Controller
    {
        private readonly ExpanseDbContext db;
        private readonly IAccountRepo accountRepo;
        public AccountController(ExpanseDbContext db, IAccountRepo accountRepo)
        {
            this.db = db;
            this.accountRepo = accountRepo;
        }

        [Route("signup")]
        public IActionResult signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task< IActionResult> signup(Signup signup)
        {
            if (ModelState.IsValid)
            {
                var result = await accountRepo.CreateAsync(signup);
                if (result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                ModelState.Clear();
            }
            return RedirectToAction("login","Account");
        }
        [Route("login")]
        public IActionResult login()
        {
            return View();
        }
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult>login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = await accountRepo.PasswordSignInAsync(login);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
            {
                    ModelState.AddModelError("", "Failed to login");
                }
                ModelState.Clear();
            }

            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await accountRepo.SignoutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
