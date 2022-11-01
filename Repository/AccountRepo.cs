using expanse_Tracker.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace expanse_Tracker.Repository
{
    public class AccountRepo : IAccountRepo
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AccountRepo(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateAsync(Signup usermodel)
        {
            var user = new ApplicationUser()
            {
                FirstName = usermodel.FirstName,
                LastName = usermodel.LastName,
                Email = usermodel.Email,
                UserName = usermodel.Email
            };
            var result = await userManager.CreateAsync(user, usermodel.Password);
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(Login login)
        {
          var result= await signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false);
            return result;
        }
        public async Task SignoutAsync()
        {
            await signInManager.SignOutAsync();
        }

    }
}
