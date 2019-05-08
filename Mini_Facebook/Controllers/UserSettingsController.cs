using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mini_Facebook.Data;
using Mini_Facebook.Models;

namespace Mini_Facebook.Controllers
{
    public class UserSettingsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public UserSettingsController(ApplicationDbContext DB, SignInManager<User> signIn, UserManager<User> manager)
        {
            context = DB;
            signInManager = signIn;
            userManager = manager;
        }

        public IActionResult Index()
        {
            string id = userManager.GetUserId(User);
            return View(context.Users.Find(id));
        }

        public IActionResult Settings(string id)
        {
            id = userManager.GetUserId(User);
            return PartialView(context.Users.Find(id));
        }

        [HttpPost]
        public IActionResult Settings(User user, string NewPass, string ConPass)
        {
            User u = context.Users.Find(userManager.GetUserId(User));
            var result = signInManager.CheckPasswordSignInAsync(u, user.PasswordHash, true);
            if (result.IsCompletedSuccessfully)
            {
                //Old Password is true
                //check if New password = Confirmed Password
                if (NewPass == ConPass)
                {
                    var token = userManager.GeneratePasswordResetTokenAsync(u);
                    var res = userManager.ResetPasswordAsync(u, token.Result, NewPass).Result;
                    if (res.Succeeded)
                    {
                        context.SaveChanges();
                        ViewBag.Message = "Password Updated Successfully";
                        return StatusCode(200);
                    }
                    else
                    {
                        var Result = res.Errors.Select(e => e.Description);
                        foreach (var item in Result)
                        {
                            ViewBag.Error = item;
                        }
                    }
                }
            }
            Response.StatusCode = 500;
            return StatusCode(404);
        }
    }
}