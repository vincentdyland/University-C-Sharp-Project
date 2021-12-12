using JustBlog.Core;
using JustBlog.Core.Entities;
using JustBlog.Core.Service;
using JustBlog.Ui.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using JustBlog.Ui.Areas.Admin.Models;
using JustBlog.Utilities;

namespace JustBlog.Ui.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PostController : Controller
    {
        readonly AppDbContext appDbContext = new AppDbContext();

        public ActionResult Dashboard()
        {
            var posts = appDbContext.Posts.ToList();
            ApplicationDbContext UsersContext = new ApplicationDbContext();
            var user = UsersContext.Users.ToList();
            TempData["users"] = user;
            return View(posts);
        }

        public ActionResult Create()
        {
            var categories = appDbContext.Categories.ToList();
            TempData["Categories"] = categories;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CreatePostModel model, int[] Ids)
        {
            var categories = appDbContext.Categories.ToList();
            TempData["Categories"] = categories;
            try
            {
                if (ModelState.IsValid)
                {
                    Post post = new Post();

                    if (model.Slug == null || model.Slug == "")
                    {
                        model.Slug = AppUtilities.GenerateSlug(model.Title);
                        post.Slug = AppUtilities.GenerateSlug(model.Title);
                    }
                    foreach (var item in appDbContext.Posts)
                    {
                        if (item.Slug == model.Slug)
                        {
                            ModelState.AddModelError("Slug", "Nhập chuỗi Url khác");
                            return View(model);
                        }
                        else
                        {
                            post.Slug = model.Slug;
                        }
                    }
                    post.Title = model.Title;
                    post.Content = model.Content;
                    post.Description = model.Description;
                    post.AuthorId = model.AuthorId;
                    post.DateCreated = DateTime.Now;
                    post.DateUpdated = DateTime.Now;
                    post.AuthorId = User.Identity.GetUserId();
                    post.Status = 1;

                    appDbContext.Posts.Add(post);
                    appDbContext.SaveChanges();

                    if (Ids != null)
                    {
                        foreach(var item in Ids)
                        {
                            appDbContext.PostCategories.Add(new PostCategory
                            {
                                CategoryID = item,
                                PostID = post.Id
                            });
                        }
                    }
                    appDbContext.SaveChanges();
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View();
        }

        public ActionResult Edit(int Id)
        {
            var post = appDbContext.Posts.Where(P => P.Id == Id).FirstOrDefault();
            if (post != null)
            {
                CreatePostModel createPostModel = new CreatePostModel
                {
                    PostCategories = appDbContext.PostCategories.Where(p => p.PostID == Id).ToList(),
                    Id = Id,
                    Content = post.Content,
                    Description = post.Description,
                    Title = post.Title
                };

                ApplicationDbContext UsersContext = new ApplicationDbContext();
                var user = UsersContext.Users.Where(u => u.Id == post.AuthorId).FirstOrDefault().UserName.ToString();


                //TempData Category
                var categories = appDbContext.Categories.ToList();
                TempData["Categories"] = categories;
                TempData["AuthorName"] = user;
                return View(createPostModel);
            }
            
            return new HttpNotFoundResult("optional description");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(CreatePostModel model, int[] Ids)
        {
            //TempData Category
            var categories = appDbContext.Categories.ToList();
            TempData["Categories"] = categories;
            try
            {
                if (ModelState.IsValid)
                {
                    appDbContext.Posts.Where(P => P.Id == model.Id).FirstOrDefault().Title = model.Title;
                    appDbContext.Posts.Where(P => P.Id == model.Id).FirstOrDefault().Description = model.Description;
                    appDbContext.Posts.Where(P => P.Id == model.Id).FirstOrDefault().Content = model.Content;
                    appDbContext.Posts.Where(P => P.Id == model.Id).FirstOrDefault().DateUpdated = DateTime.Now;
                    appDbContext.SaveChanges();

                    appDbContext.PostCategories.RemoveRange(appDbContext.PostCategories.Where(p => p.PostID == model.Id));
                    if(Ids != null)
                    {
                        foreach (var item in Ids)
                        {
                            appDbContext.PostCategories.Add(new PostCategory
                            {
                                CategoryID = item,
                                PostID = model.Id
                            });
                        }
                    }
                    appDbContext.SaveChanges();
                }
                return RedirectToAction("Dashboard");
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(model);
        }

        //Delete
        public ActionResult Delete(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    appDbContext.PostCategories.RemoveRange(appDbContext.PostCategories.Where(p => p.PostID == Id));
                    appDbContext.Posts.Remove(appDbContext.Posts.Where(P => P.Id == Id).FirstOrDefault());
                    appDbContext.SaveChanges();
                    return RedirectToAction("Dashboard");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View();
        }
    }
}