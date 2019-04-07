using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mini_Facebook.Data;
using Mini_Facebook.Models;

namespace Mini_Facebook.Controllers
{
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext context;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AdminController(ApplicationDbContext DB, SignInManager<User> signIn, UserManager<User> manager)
        {
            context = DB;
            signInManager = signIn;
            userManager = manager;
        }

        #region Manage Users

        public IActionResult Index()
        {
            //var x=context.Users.Select(v=>v.Role);
            var x = context.Users.Select(v => v.Role);
            //ViewBag.roleArray=context.Users.Select(v=>v.Role).ToArray();
            ViewBag.roleArray = context.Roles.ToArray();
            var c = x;
            return View(context.Users.ToList());
        }
        public IActionResult getAllUsers()
        {
            ViewBag.roleArray = context.Roles.ToArray();
            //ViewBag.rolLst = new SelectList(context.Roles, "Id", "Name");
            //ViewBag.rolLst = context.Roles.ToArray();
            //ViewData["heba"] = context.Roles.ToList();
            return PartialView(context.Users.ToList());
        }
        public IActionResult Block(string uID, bool usStat)
        {
            var item = context.Users.Find(uID);
            item.Blocked = usStat;
            context.SaveChanges();
            return RedirectToAction("getAllUsers");
            //return Redirect(Request.Path);
        }
        public IActionResult Delete(string id)
        {
            var item = context.Users.Find(id);
            item.Deleted = true;
            context.SaveChanges();
            return RedirectToAction("getAllUsers");
            //return Redirect(Request.Path);
        }
        public IActionResult Blockser(string uID, bool usStat, string serchText)
        {
            var item = context.Users.Find(uID);
            item.Blocked = usStat;
            context.SaveChanges();

            return RedirectToAction("searfun", routeValues: new { serTxt = serchText });
            //return Redirect(Request.Path);
        }
        public IActionResult searfun(string serTxt)
        {
            var users = context.Users.ToList();
            var res = users.Where(s => s.UserName.Contains(serTxt));
            //return PartialView(res);
            ViewBag.roleArray = context.Roles.ToArray();

            ViewData["searchTxt"] = serTxt;
            return PartialView("searfun", res);

        }
        public IActionResult edit(string id)
        {
            User _user = context.Users.Find(id);
            Role roleObj = context.Roles.Find(id);
            var lst = context.Roles.GroupBy(o => new { o.Name })
                                       .Select(o => o.FirstOrDefault()).ToList();
            ViewBag.rolLst = new SelectList(lst, "Id", "Name", _user.Id);
            return PartialView(_user);
            // return PartialView("create",movie);
        }
        [HttpPost]
        public IActionResult edit(User _user)
        {
            User user = context.Users.Find(_user.Id);
            user.UserName = _user.UserName;
            user.Email = _user.Email;
            context.SaveChanges();
            return PartialView("getAllUsers", context.Users.ToList());
        }
        public IActionResult ChangeRole(string RolId, string UserId)/*(string RolName, string UserID)*/
        {

            var rolobj = context.Users.Where(e => e.Id == UserId).FirstOrDefault();
            rolobj.RoleID = RolId;
            // Role f=rolobj.
            // rolobj.Role.Name = RolName;
            // rolobj.Name = RolName;
            context.SaveChanges();
            return RedirectToAction("getAllUsers");
            //var rolobj = context.Users.Where(e => e.Id == UserID).Select(r => r.Role).FirstOrDefault();
            //rolobj.Name = RolName;
            //// Role f=rolobj.
            //// rolobj.Role.Name = RolName;
            //// rolobj.Name = RolName;
            //context.SaveChanges();
            //return RedirectToAction("getAllUsers");
        }

        public IActionResult ChangeRoleSerch(string RolName, string UserID, string serchText)
        {

            var rolobj = context.Users.Where(e => e.Id == UserID).Select(r => r.Role).FirstOrDefault();
            rolobj.Name = RolName;
            // Role f=rolobj.
            // rolobj.Role.Name = RolName;
            // rolobj.Name = RolName;
            context.SaveChanges();
            return RedirectToAction("searfun", routeValues: new { serTxt = serchText });
        }
        public IActionResult create()
        {
            //ViewBag.rollst= context.Roles.ToArray();
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(/*string _email, string _password, string _confirmedPassword*/ Mini_Facebook.Views.Admin.inputModel c, string _rol)
        {
            //if (ModelState.IsValid)
            //{
            //    //var user = new User { UserName = Input.Email, Email = Input.Email };
            //    //
            //}

            var findEmailExistance = userManager.FindByEmailAsync(c.Email);
            if (ModelState.IsValid)
            {
                if (findEmailExistance.Result == null)
                {
                    //if(_password==_confirmedPassword)
                    //{
                    var user = new User() { UserName = c.Email, Email = c.Email };
                    user.RoleID = _rol;
                    var result = await userManager.CreateAsync(user, c.Password);

                    // }
                }
            }
            return RedirectToAction("getAllUsers");

        }
        #endregion

        //public IActionResult Users()
        //{
        //    //userManager.
        //    return View();
        //}

        //public IActionResult Roles()
        //{
        //    return View();
        //}

        #region Manage Roles

        public IActionResult RoleIndex()
        {
            return PartialView(context.Roles.Where(r => r.Deleted == false).ToList());
        }

        public IActionResult RoleGetAll()
        {
            return PartialView(context.Roles.Where(r => r.Deleted == false).ToList());
        }

        // GET: Role/Create
        public IActionResult RoleCreate()
        {
            return PartialView();
        }

        // POST: Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RoleCreate([Bind("Description,Deleted,Id,Name,NormalizedName,ConcurrencyStamp")] Role role)
        {
            if (ModelState.IsValid)
            {
                context.Add(role);
                await context.SaveChangesAsync();
                return PartialView("RoleGetAll", context.Roles.Where(r => r.Deleted == false).ToList());
            }
            return PartialView("RoleGetAll", context.Roles.ToList());
        }

        // GET: Role/Edit/5
        public async Task<IActionResult> RoleEdit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return PartialView(await context.Roles.FindAsync(id));
        }

        // POST: Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RoleEdit(Role role)
        {

            if (ModelState.IsValid)
            {

                var r = await context.Roles.FindAsync(role.Id);
                r.Name = role.Name;
                r.Description = role.Description;
                context.Roles.Update(r);
                await context.SaveChangesAsync();
                return PartialView("RoleGetAll", context.Roles.Where(rn => rn.Deleted == false).ToList());
            }
            return View(role);
        }

        // GET: Role/Delete/5
        public async Task<IActionResult> RoleDelete(string id)
        {
            var role = await context.Roles.FindAsync(id);
            role.Deleted = true;
            context.Roles.Update(role);
            await context.SaveChangesAsync();
            return PartialView("RoleGetAll", context.Roles.Where(r => r.Deleted == false).ToList());
        }

        private bool RoleExists(string id)
        {
            return context.Roles.Any(e => e.Id == id);
        }
        #endregion

        #region Admin Settings
        public IActionResult Settings(string id)
        {
            return PartialView(context.Users.Find(id));
        }


        [HttpPost]
        public IActionResult Settings(User user, string NewPass, string ConPass)
        {
            User u = context.Users.Find(user.Id);
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

        #endregion
    }
}