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
            ViewBag.ALLUsers = context.Users.Where(u => u.EmailConfirmed == false);
            var res = context.Posts.Where(u => String.Equals(u.UserID, ID)).Include(p => p.User).Include(l => l.Likes).Include(c => c.Comments).ToList();
            //Get My Friends IDs
            var friends = context.Friendships.Where(u => u.UserID == ID && u.status == FriendStatus.Accepted).Select(u => u.FriendID);
           
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
                var onlyfriendposts = context.Posts.Where(u => u.UserID == friend.Id).Include(l => l.Likes).Include(c => c.Comments).ToList();
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

        //Search Section
        [HttpGet]
        public IActionResult Search(String name)
        {
            ID = userManager.GetUserId(User);
            var users = context.Users.Where(n => (n.FirstName.Contains(name)|| n.LastName.Contains(name)) && n.Id != ID).ToList();
            List<User> friendsUsers = new List<User>();
            List<User> otherUsers = new List<User>();
            foreach (var user in users)
            {
                var uid = user.Id;
                var f = context.Friendships.Count(i => i.UserID == ID && i.FriendID == uid && i.status==FriendStatus.Accepted);
                if (f > 0)
                    friendsUsers.Add(user);
                else
                    otherUsers.Add(user);
            }
            ViewBag.friendUsers = friendsUsers;
            return PartialView(otherUsers);
        }

        //========================= Posts Section ===============================
        public IActionResult Posts()
        {
            ID = userManager.GetUserId(User);
            ViewBag.ALLUsers = context.Users.Where(u => u.EmailConfirmed == false);
            var res = context.Posts.Where(u => String.Equals(u.UserID, ID)).Include(p => p.User).Include(c => c.Comments).ToList();

            //Get My Friends IDs
            var friends = context.Friendships.Where(u => u.UserID == ID && u.status == FriendStatus.Accepted).Select(u => u.FriendID);
           
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
        public IActionResult DeletePost(int id)
        {
            var post = context.Posts.Where(l => l.UserID == userManager.GetUserId(User) && l.ID == id).FirstOrDefault();
            post.Deleted = true;
            context.SaveChanges();
            ID = userManager.GetUserId(User);
            var res = context.Posts.Include(l => l.Likes).Include(u => u.User).Include(c => c.Comments).Where(u => u.UserID == ID && u.Deleted == false).OrderByDescending(d => d.Date).ToList();
            /////////////new
            //var res = context.Posts.Where(u => String.Equals(u.UserID, ID)).Include(p => p.User).Include(l => l.Likes).Include(c => c.Comments).ToList();

            //Get My Friends IDs
            var friends = context.Friendships.Where(u => u.UserID == ID).Select(u => u.FriendID);
            var friends2 = context.Friendships.Where(u => (u.FriendID == ID) && u.status == FriendStatus.Accepted).Select(u => u.UserID);
            var AllFriends = friends2.Union(friends);

            //Get My Friends
            List<User> Myfriends = new List<User>();
            foreach (var friendID in AllFriends)
            {
                Myfriends.Add(context.Users.Find(friendID));
            }

            //Get Post of Me and MyFriends
            List<Post> FriPosts = new List<Post>();
            foreach (var friend in Myfriends)
            {
                var onlyfriendposts = context.Posts.Where(u => u.UserID == friend.Id).Include(l => l.Likes).Include(c => c.Comments).ToList();
                foreach (var p in onlyfriendposts)
                {
                    FriPosts.Add(p);
                }
            }

            //Get My Posts 
            //Alllllll Posts in FriPosts
            foreach (var p in res)
            {
                FriPosts.Add(p);
            }
            return PartialView("Posts", FriPosts.OrderByDescending(d => d.Date));
        }

        [HttpPost]
        public IActionResult Addpost(Post p, string PostBody)
        {
            ID = userManager.GetUserId(User);
            p.Body = PostBody;
            p.Date = DateTime.Now;
            p.Deleted = false;
            p.UserID = userManager.GetUserId(User);
            context.Posts.Add(p);
            context.SaveChanges();

            //friends posts
            ID = userManager.GetUserId(User);
            var res = context.Posts.Include(l => l.Likes).Include(u => u.User).Include(c => c.Comments).Where(u => u.UserID == ID && u.Deleted == false).OrderByDescending(d => d.Date).ToList();

            //Get My Friends IDs
            var friends = context.Friendships.Where(u => u.UserID == ID && u.status == FriendStatus.Accepted).Select(u => u.FriendID);

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
                var onlyfriendposts = context.Posts.Where(u => u.UserID == friend.Id && u.Deleted == false).Include(c => c.Comments).Include(l => l.Likes).ToList();
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
            ViewBag.ALLUsers = context.Users.Where(u => u.EmailConfirmed == false);

            return PartialView("Posts", FriPosts.OrderByDescending(d => d.Date));
        }

        //================== Comments Section ==================================
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
            ViewBag.ALLUsers = context.Users.Where(u => u.EmailConfirmed == false);

            var res = context.Posts.Include(l => l.Likes).Include(u => u.User).Include(c => c.Comments).Where(u => u.UserID == ID && u.Deleted == false).OrderByDescending(d => d.Date).ToList();
            return RedirectToAction("Posts", res);
        }

        public IActionResult DeleteComment(int ComID)
        {
            Comment com = context.Comments.FirstOrDefault(c => c.ID == ComID);
            com.Deleted = true;
            context.SaveChanges();
            ViewBag.ALLUsers = context.Users.Where(u => u.EmailConfirmed == false);

            var res = context.Posts.Where(u => String.Equals(u.UserID, ID)).Include(p => p.User).Include(l => l.Likes).Include(c => c.Comments).ToList();
            return RedirectToAction("Posts", context.Posts.Where(u => u.UserID == ID).OrderByDescending(d => d.Date));
        }


        //================== Likes Section ==================================
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
            var res = context.Posts.Include(l => l.Likes).Include(u => u.User).Include(c => c.Comments).Where(u => u.UserID == userID && u.Deleted == false).OrderByDescending(d => d.Date).ToList();

            //Get My Friends IDs
            var friends = context.Friendships.Where(u => u.UserID == userID).Select(u => u.FriendID);
            var friends2 = context.Friendships.Where(u => (u.FriendID == userID) && u.status == FriendStatus.Accepted).Select(u => u.UserID);
            var AllFriends = friends2.Union(friends);

            //Get My Friends
            List<User> Myfriends = new List<User>();
            foreach (var friendID in AllFriends)
            {
                Myfriends.Add(context.Users.Find(friendID));
            }

            //Get Post of Me and MyFriends
            List<Post> FriPosts = new List<Post>();
            foreach (var friend in Myfriends)
            {
                var onlyfriendposts = context.Posts.Where(u => u.UserID == friend.Id).Include(l => l.Likes).Include(c => c.Comments).ToList();
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

            return PartialView("Posts", FriPosts.OrderByDescending(d => d.Date));
            //return PartialView("Posts", re);
        }

        /////////////new
        public IActionResult likeUsers(int id)
        {
            var res = context.Likes.Include(u => u.User).Where(p => p.PostID == id && p.Deleted == false).ToList();

            return PartialView(res);
        }

    }
}