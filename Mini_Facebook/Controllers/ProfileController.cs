using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_Facebook.Data;
using Mini_Facebook.Models;

namespace Mini_Facebook.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IHostingEnvironment he;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        public string ID { get; set; }

        public ProfileController(ApplicationDbContext _context, IHostingEnvironment _ihostingEnviroment, SignInManager<User> signIn, UserManager<User> manager)
        {
            context = _context;
            signInManager = signIn;
            userManager = manager;
            he = _ihostingEnviroment;
        }

        public IActionResult Index(string id)
        {
            ViewBag.ALLUsers = context.Users.Where(u => u.EmailConfirmed == false);
            if (id == null)
                ID = userManager.GetUserId(User);
            else
                ID = id;
            ViewBag.UserProfileID = ID;
            var res = context.Posts.Where(u => String.Equals(u.UserID, ID)).Include(p => p.User).Include(l => l.Likes).Include(c => c.Comments).ToList();
            ViewData["imgSrc"] = context.Users.Find(ID).PhotoSrc;
            ViewBag.user = context.Users.Find(ID);

            ViewBag.friends = context.Friendships.Include(u=>u.User).Include(f=>f.Friend).Where(us=>us.UserID== userManager.GetUserId(User) && us.status==FriendStatus.Accepted);
            ViewBag.PendingFriends = context.Friendships.Include(u=>u.User).Include(f=>f.Friend).Where(us=>us.UserID== userManager.GetUserId(User) && us.status==FriendStatus.Thinking);

            var friend = context.Friendships.Where(u => u.UserID == userManager.GetUserId(User)).Where(fr => fr.FriendID == ID).FirstOrDefault();
            if (friend == null)
                ViewBag.frndBtn = "Add Friend";
            else if (friend.status == FriendStatus.Declined)
                ViewBag.frndBtn = "Add Friend";
            else if (friend.status == FriendStatus.Pending)
                ViewBag.frndBtn = "Cancel Request";
            else if (friend.status == FriendStatus.Thinking)
                ViewBag.frndBtn = "Accept";
            else // friend.status == FriendStatus.Accepted
                ViewBag.frndBtn = "Remove Friend";

            return View(context.Posts.Where(u => String.Equals(u.UserID, ID) && u.Deleted == false).OrderByDescending(d => d.Date));
        }

        public IActionResult header()
        {
            return PartialView();
        }

        public IActionResult changePic(IFormFile pic)
        {
            ID = userManager.GetUserId(User);
            if (pic != null)
            {
                var filename = Path.Combine(he.WebRootPath + "\\UsersImages\\", Path.GetFileName(pic.FileName));
                pic.CopyTo(new FileStream(filename, FileMode.Create));
                // ViewData["userpic"] = "/UsersImages/" + Path.GetFileName(filename);
                context.Users.Find(ID).PhotoSrc = "/UsersImages/" + Path.GetFileName(filename);
                context.SaveChanges();
            }
            ViewData["imgSrc"] = context.Users.Find(ID).PhotoSrc;
            return PartialView("header");
        }

        public IActionResult userInfo()
        {
            return PartialView();
        }

        public async Task<IActionResult> editUserInfoAsync(User user, string password, string confirm)
        {
            ID = userManager.GetUserId(User);
            var editedUser = context.Users.Find(ID);
            editedUser.FirstName = user.FirstName ?? editedUser.FirstName;
            editedUser.LastName = user.LastName ?? editedUser.LastName;
            editedUser.UserName = user.UserName ?? editedUser.UserName;
            if (password == confirm)
            {
                await userManager.RemovePasswordAsync(editedUser);
                await userManager.AddPasswordAsync(editedUser, password);

            }

            context.SaveChanges();
            ViewBag.user = editedUser;
            return PartialView("userInfo");
        }

        public IActionResult Posts()
        {
            ID = userManager.GetUserId(User);
            ViewBag.ALLUsers = context.Users.Where(u => u.EmailConfirmed == false);
            return PartialView(context.Posts.Where(u => u.UserID == ID && u.Deleted == false).OrderByDescending(d => d.Date));
        }

        [HttpPost]
        public IActionResult Addpost(Post p,string PostBody)
        {
            ID = userManager.GetUserId(User);
            p.Body = PostBody;
            p.Date = DateTime.Now;
            p.Deleted = false;
            p.UserID = userManager.GetUserId(User);
            context.Posts.Add(p);
            context.SaveChanges();
            var re = context.Posts.Include(l => l.Likes).Include(c => c.Comments).Include(u => u.User).Where(u => u.UserID == ID && u.Deleted == false).OrderByDescending(d => d.Date).ToList();
            return PartialView("Posts", re);
        }

        public IActionResult Like(Like like, int id)
        {
            var userID = userManager.GetUserId(User);
            if (context.Likes.Where(l => l.UserID == userID && l.PostID == id).Count() == 0)
            {
                like.Deleted = false;
                like.PostID = id;
                like.UserID = userID;
                context.Likes.Add(like);
            }
            else
            {
                var likeObj = context.Likes.Where(l => l.UserID == userID && l.PostID == id).FirstOrDefault();
                if (likeObj.Deleted == true)
                    likeObj.Deleted = false;
                else
                    likeObj.Deleted = true;
            }
            context.SaveChanges();
            var re = context.Posts.Include(l => l.Likes).Include(u => u.User).Include(c => c.Comments).Where(u => u.UserID == userID && u.Deleted == false).OrderByDescending(d => d.Date).ToList();
            return PartialView("Posts", re);
        }

        public IActionResult likeUsers(int id)
        {
            var res = context.Likes.Include(u => u.User).Where(p => p.PostID == id && p.Deleted == false).ToList();
            return PartialView(res);
        }

        public IActionResult DeletePost(int id)
        {
            var post = context.Posts.Where(l => l.UserID == userManager.GetUserId(User) && l.ID == id).FirstOrDefault();
            post.Deleted = true;
            context.SaveChanges();
            ID = userManager.GetUserId(User);
            var re = context.Posts.Include(l => l.Likes).Include(u => u.User).Include(c => c.Comments).Where(u => u.UserID == ID && u.Deleted == false).OrderByDescending(d => d.Date).ToList();
            return PartialView("Posts", re);
        }

        public IActionResult sendRequest(string friendId)
        {
            var friend = context.Friendships.Where(u => u.UserID == userManager.GetUserId(User)).Where(fr => fr.FriendID == friendId).FirstOrDefault();

            if (friend == null)
            {
                var friendship = new Friendship { UserID = userManager.GetUserId(User).ToString(), FriendID = friendId, Deleted = false, status = FriendStatus.Pending };
                var friendship2 = new Friendship { UserID = friendId, FriendID = userManager.GetUserId(User).ToString(), Deleted = false, status = FriendStatus.Thinking };
                ViewBag.frndBtn = "Cancel Request";
                context.Friendships.Add(friendship);
            }
            else if (friend.status == FriendStatus.Declined)
            {
                var F = context.Friendships.Where(u => u.UserID == userManager.GetUserId(User)).Where(fr => fr.FriendID == friendId).FirstOrDefault();
                var F2 = context.Friendships.Where(u => u.UserID == friendId).Where(fr => fr.FriendID == userManager.GetUserId(User)).FirstOrDefault();
                F.status = FriendStatus.Pending;
                F2.status = FriendStatus.Thinking;
                ViewBag.frndBtn = "Cancel Request";
            }
            else if (friend.status == FriendStatus.Pending)
            {
                var F = context.Friendships.Where(u => u.UserID == userManager.GetUserId(User)).Where(fr => fr.FriendID == friendId).FirstOrDefault();
                var F2 = context.Friendships.Where(u => u.UserID == friendId).Where(fr => fr.FriendID == userManager.GetUserId(User)).FirstOrDefault();
                F.status = FriendStatus.Declined;
                F2.status = FriendStatus.Declined;
                ViewBag.frndBtn = "Add Friend";
            }
            else if (friend.status == FriendStatus.Thinking) //Accept-Remove Request .. will handle Accept
            {
                var F = context.Friendships.Where(u => u.UserID == userManager.GetUserId(User)).Where(fr => fr.FriendID == friendId).FirstOrDefault();
                var F2 = context.Friendships.Where(u => u.UserID == friendId).Where(fr => fr.FriendID == userManager.GetUserId(User)).FirstOrDefault();
                F.status = FriendStatus.Accepted;
                F2.status = FriendStatus.Accepted;
                ViewBag.frndBtn = "Remove Friend";
            }
            else // friend.status == FriendStatus.Accepted
            {
                var F = context.Friendships.Where(u => u.UserID == userManager.GetUserId(User)).Where(fr => fr.FriendID == friendId).FirstOrDefault();
                var F2 = context.Friendships.Where(u => u.UserID == friendId).Where(fr => fr.FriendID == userManager.GetUserId(User)).FirstOrDefault();
                F.status = FriendStatus.Declined;
                F2.status = FriendStatus.Declined;
                ViewBag.frndBtn = "Add Friend";
            }
            context.SaveChanges();
            return PartialView("FriendRequestState", friendId);
        }

        public IActionResult sendRequestP(string friendId)
        {
            var F = context.Friendships.Where(u => u.UserID == userManager.GetUserId(User)).Where(fr => fr.FriendID == friendId).FirstOrDefault();
            var F2 = context.Friendships.Where(u => u.UserID == friendId).Where(fr => fr.FriendID == userManager.GetUserId(User)).FirstOrDefault();
            F.status = FriendStatus.Declined;
            F2.status = FriendStatus.Declined;
            
            context.SaveChanges();
            ViewBag.friends = context.Friendships.Include(u => u.User).Include(f => f.Friend).Where(us => us.UserID == userManager.GetUserId(User) && us.status == FriendStatus.Accepted);
            ViewBag.PendingFriends = context.Friendships.Include(u => u.User).Include(f => f.Friend).Where(us => us.UserID == userManager.GetUserId(User) && us.status == FriendStatus.Thinking);

            return PartialView("UserFriends");
        }

        public IActionResult sendRequestReq(string friendId)
        {
            var F = context.Friendships.Where(u => u.UserID == userManager.GetUserId(User)).Where(fr => fr.FriendID == friendId).FirstOrDefault();
            var F2 = context.Friendships.Where(u => u.UserID == friendId).Where(fr => fr.FriendID == userManager.GetUserId(User)).FirstOrDefault();
            F.status = FriendStatus.Accepted;
            F2.status = FriendStatus.Accepted;

            context.SaveChanges();
            ViewBag.PendingFriends = context.Friendships.Include(u => u.User).Include(f => f.Friend).Where(us => us.UserID == userManager.GetUserId(User) && us.status == FriendStatus.Thinking);
            ViewBag.friends = context.Friendships.Include(u => u.User).Include(f => f.Friend).Where(us => us.UserID == userManager.GetUserId(User) && us.status == FriendStatus.Accepted);

            return PartialView("UserFriends");
        }

        public IActionResult removeRequest(string friendId)
        {

            var friend = context.Friendships.Where(u => u.UserID == userManager.GetUserId(User)).Where(fr => fr.FriendID == friendId).FirstOrDefault();
            var F = context.Friendships.Where(u => u.UserID == userManager.GetUserId(User)).Where(fr => fr.FriendID == friendId).FirstOrDefault();
            var F2 = context.Friendships.Where(u => u.UserID == friendId).Where(fr => fr.FriendID == userManager.GetUserId(User)).FirstOrDefault();
            F.status = FriendStatus.Declined;
            F2.status = FriendStatus.Declined;
            ViewBag.frndBtn = "Add Friend";

            context.SaveChanges();
            return PartialView("FriendRequestState", friendId);

        }

        public IActionResult removeRequestReq(string friendId)
        {
            var friend = context.Friendships.Where(u => u.UserID == userManager.GetUserId(User)).Where(fr => fr.FriendID == friendId).FirstOrDefault();
            var F = context.Friendships.Where(u => u.UserID == userManager.GetUserId(User)).Where(fr => fr.FriendID == friendId).FirstOrDefault();
            var F2 = context.Friendships.Where(u => u.UserID == friendId).Where(fr => fr.FriendID == userManager.GetUserId(User)).FirstOrDefault();
            F.status = FriendStatus.Declined;
            F2.status = FriendStatus.Declined;

            context.SaveChanges();
            ViewBag.PendingFriends = context.Friendships.Include(u => u.User).Include(f => f.Friend).Where(us => us.UserID == userManager.GetUserId(User) && us.status == FriendStatus.Thinking);
            ViewBag.friends = context.Friendships.Include(u => u.User).Include(f => f.Friend).Where(us => us.UserID == userManager.GetUserId(User) && us.status == FriendStatus.Accepted);

            return PartialView("UserFriends");
        }

        //======== Commenting  System ==========//
        [HttpPost]
        public IActionResult AddComment(Comment Com, string CommentBody, int postid , string profid)
        {
            ID = userManager.GetUserId(User);
            Com.Body = CommentBody;
            Com.Deleted = false;
            Com.PostID = postid;
            Com.UserID = ID;
            context.Comments.Add(Com);
            context.SaveChanges();
            ViewBag.ALLUsers = context.Users.Where(u => u.EmailConfirmed == false);
            var res = context.Posts.Where(u => u.UserID == profid && u.Deleted == false).Include(p => p.User).Include(c => c.Comments).Include(l => l.Likes).ToList();
            return PartialView("Posts", res.OrderByDescending(d => d.Date));
        }

        public IActionResult DeleteComment(int ComID, string profid)
        {
            ViewBag.ALLUsers = context.Users.Where(u => u.EmailConfirmed == false);
            ID = userManager.GetUserId(User);
            Comment com = context.Comments.FirstOrDefault(c => c.ID == ComID);
            com.Deleted = true;
            context.SaveChanges();
            var res = context.Posts.Where(u => u.UserID == profid && u.Deleted == false).Include(p => p.User).Include(c => c.Comments).Include(l => l.Likes).ToList();
            return PartialView("Posts", res.OrderByDescending(d => d.Date));
        }
    }
}