using JustBlog.Core;
using JustBlog.Core.Entities;
using JustBlog.Ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustBlog.Ui.Controllers
{
    public class HomeController : Controller
    {
        readonly AppDbContext dbContext = new AppDbContext();
        // GET: Post

        public ActionResult PostDetail(string Slug)
        {
            var post = dbContext.Posts.Where(p => p.Slug == Slug).FirstOrDefault();

            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        public ActionResult PostList()
        {
            ApplicationDbContext UsersContext = new ApplicationDbContext();

            var user = UsersContext.Users.ToList();
            TempData["users"] = user;
            var posts = dbContext.Posts.ToList();
            return View(posts);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}