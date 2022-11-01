using expanse_Tracker.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace expanse_Tracker.Repository
{
    public interface IAccountRepo
    {
        Task<IdentityResult> CreateAsync(Signup usermodel);
        Task<SignInResult> PasswordSignInAsync(Login login);
        Task SignoutAsync();
    }
}