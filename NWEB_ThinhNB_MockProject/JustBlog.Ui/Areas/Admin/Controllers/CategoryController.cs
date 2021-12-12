using JustBlog.Core;
using JustBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustBlog.Ui.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        readonly AppDbContext dbContext = new AppDbContext();
        // GET: Admin/Category
        public ActionResult Controller()
        {
            var categories = dbContext.Categories.ToList();
            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Category model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Category category = new Category
                    {
                        Name = model.Name,
                        Slug = model.Slug,
                        Status = 1
                    };

                    dbContext.Categories.Add(category);

                    dbContext.SaveChanges();
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View();
        }
        public ActionResult Delete(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.PostCategories.RemoveRange(dbContext.PostCategories.Where(postCategories => postCategories.CategoryID == Id));
                    dbContext.Categories.Remove(dbContext.Categories.Where(categories => categories.Id == Id).FirstOrDefault());
                    dbContext.SaveChanges();
                    return RedirectToAction("Controller");
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
            var category = dbContext.Categories.Where(categories => categories.Id == Id).FirstOrDefault();
            if (category != null)
            {
                return View(category);
            }

            return new HttpNotFoundResult("optional description");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Category model)
        {
            //TempData Category
            var categories = dbContext.Categories.ToList();
            TempData["Categories"] = categories;
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.Categories.Where(P => P.Id == model.Id).FirstOrDefault().Name = model.Name;
                    dbContext.Categories.Where(P => P.Id == model.Id).FirstOrDefault().Status = model.Status;
                    dbContext.Categories.Where(P => P.Id == model.Id).FirstOrDefault().Slug = model.Slug;

                    dbContext.SaveChanges();
                }
                return RedirectToAction("Controller");
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(model);
        }
    }
}