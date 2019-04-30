using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_Facebook.Data;
using Mini_Facebook.Models;

namespace Mini_Facebook.Controllers
{
    public class UserHomeController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public string ID { get; set; }
        public UserHomeController(ApplicationDbContext _context, SignInManager<User> signIn, UserManager<User> manager)
        {
            context = _context;
            signInManager = signIn;
            userManager = manager;
        }

        public IActionResult Index()
        {
            ID = userManager.GetUserId(User);
            var res = context.Posts.Where(u => String.Equals(u.UserID, ID)).Include(p => p.User).Include(c => c.Comments).ToList();
            //Get My Friends IDs
            var friends = context.Friendships.Where(u => u.UserID == ID).Select(u => u.FriendID);
            //Get My Friends
            List<User> Myfriends = new List<User>();
            foreach (var friendID in friends)
            {
                Myfriends.Add(context.Users.Find(friendID));
            }
            //Get Post of Me and MyFriends
            List<Post> FriPosts = new List<Post>();
            foreach (var friend in Myfriends)
            {
                var onlyfriendposts = context.Posts.Where(u => u.UserID == friend.Id).Include(c => c.Comments).ToList();
                foreach (var post in onlyfriendposts)
                {
                    FriPosts.Add(post);
                }
            }
            //Get My Posts 
            //Alllllll Posts in FriPosts
            foreach (var post in res)
            {
                FriPosts.Add(post);
            }
            return View(FriPosts.OrderByDescending(d => d.Date));
        }

        //Posts Section
        public IActionResult Posts()
        {
            ID = userManager.GetUserId(User);
            var res = context.Posts.Where(u => String.Equals(u.UserID, ID)).Include(p => p.User).Include(c => c.Comments).ToList();

            //Get My Friends IDs
            var friends = context.Friendships.Where(u => u.UserID == ID).Select(u => u.FriendID);

            //Get My Friends
            List<User> Myfriends = new List<User>();
            foreach (var friendID in friends)
            {
                Myfriends.Add(context.Users.Find(friendID));
            }

            //Get Post of Me and MyFriends
            List<Post> FriPosts = new List<Post>();
            foreach (var friend in Myfriends)
            {
                var onlyfriendposts = context.Posts.Where(u => u.UserID == friend.Id).Include(c => c.Comments).ToList();
                foreach (var post in onlyfriendposts)
                {
                    FriPosts.Add(post);
                }
            }

            //Get My Posts 
            //Alllllll Posts in FriPosts
            foreach (var post in res)
            {
                FriPosts.Add(post);
            }

            return PartialView(FriPosts.OrderByDescending(d => d.Date));
        }

        [HttpPost]
        public IActionResult Addpost(Post p, string PostBody)
        {
            p.Body = PostBody;
            p.Date = DateTime.Now;
            p.Deleted = false;
            p.UserID = userManager.GetUserId(User);
            context.Posts.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index", context.Posts.Where(u => u.UserID == ID).OrderByDescending(d => d.Date));
        }

        //Write Comment in post
        [HttpPost]
        public IActionResult AddComment(Comment Com, string CommentBody ,int postid)
        {
            ID = userManager.GetUserId(User);
            Com.Body = CommentBody;
            Com.Deleted = false;
            Com.PostID = postid;
            Com.UserID = ID;
            context.Comments.Add(Com);
            context.SaveChanges();
            //return RedirectToAction("Posts");
            var res = context.Posts.Where(u => String.Equals(u.UserID, ID)).Include(p => p.User).Include(c => c.Comments).ToList();
            return RedirectToAction("Posts", context.Posts.Where(u => u.UserID == ID).OrderByDescending(d => d.Date));
        }

        public IActionResult DeleteComment(int ComID)
        {
            Comment com = context.Comments.FirstOrDefault(c => c.ID == ComID);
            com.Deleted = true;
            context.SaveChanges();
            var res = context.Posts.Where(u => String.Equals(u.UserID, ID)).Include(p => p.User).Include(c => c.Comments).ToList();
            return RedirectToAction("Posts", context.Posts.Where(u => u.UserID == ID).OrderByDescending(d => d.Date));
        }

    }
}