using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace expanse_Tracker.Models
{
    public class Signup
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, EmailAddress(ErrorMessage = "Please enter a valid email address")]

        public  string  Email { get; set; }
        [Required]
        [Compare("ConfirmPassword", ErrorMessage = "Password don't match")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
