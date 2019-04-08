﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Mini_Facebook.Models;

namespace Mini_Facebook.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }


        public class ageRangeAttribute : ValidationAttribute
        {
            private int _minAge;

            public ageRangeAttribute(int minAge)
            {
                _minAge = minAge;
            }
            private DateTime getMaxDate()
            {
                var myDate = DateTime.Now;
                var maxDate = myDate.AddYears(-_minAge);
                return maxDate;
            }
            private DateTime getMinDate()
            {
                var myDate = DateTime.Now;
                var minDate = myDate.AddYears(-200);
                return minDate;
            }
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var birthDay = ((DateTime)value);

                if (birthDay >= getMaxDate() || birthDay <= getMinDate())
                {
                    return new ValidationResult(GetErrorMessage());
                }

                return ValidationResult.Success;
            }

            public string GetErrorMessage()
            {
                return $"Age must be between {_minAge} and 200.";
            }
        }
        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "You must Enter your First Name")]
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string RoleID { get; set; }
            [Required(ErrorMessage = "You must Enter your Gender")]
            public bool Gender { get; set; }
            public string PhotoSrc { get; set; }
            public string PhoneNumber { get; set; }
            public string UserName { get; set; }
            [ageRangeAttribute(6)]
            [DataType(DataType.Date)]
            public DateTime Birthdate { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                if (Input.Gender == true)
                {
                    Input.PhotoSrc = "~/images/Female1.jpg";
                }
                else
                {
                    Input.PhotoSrc = "~/images/Male1.png";
                }
                var user = new User { UserName = Input.Email, Email = Input.Email, LastName = Input.LastName, FirstName = Input.FirstName, RoleID = "2", Gender = Input.Gender, PhoneNumber = Input.PhoneNumber, Birthdate = Input.Birthdate, PhotoSrc = Input.PhotoSrc };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}