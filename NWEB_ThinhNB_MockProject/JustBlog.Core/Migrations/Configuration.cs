namespace JustBlog.Core.Migrations
{
    using Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppDbContext appDbContext)
        {
            try
            {
                var roleStore = new RoleStore<IdentityRole>(appDbContext);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var roleAdmin = new IdentityRole { Name = "Admin" };
                var roleUser = new IdentityRole { Name = "User" };

                roleManager.Create(roleAdmin);
                roleManager.Create(roleUser);
                appDbContext.SaveChanges();
                var user = new AppUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    PasswordHash = "AAIKir9RO0n4AbQ6yYOiXlbpeXuTg7i2Kf14P1YnRAXopgWQyyt/0hG5/Yiu3vw7CQ==",
                    //password:123456asdA@
                };

                var userStore = new UserStore<AppUser>(appDbContext);
                var userManager = new UserManager<AppUser>(userStore);
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Admin");

                Category category1 = new Category
                {
                    Name = "A",
                    Slug = "A",
                    Status = 1,
                };
                Category category2 = new Category
                {
                    Name = "B",
                    Slug = "B",
                    Status = 1,
                };
                Category category3 = new Category
                {
                    Name = "C",
                    Slug = "C",
                    Status = 1,
                };
                Category category4 = new Category
                {
                    Name = "D",
                    Slug = "D",
                    Status = 1,
                };
                Category category5 = new Category
                {
                    Name = "E",
                    Slug = "E",
                    Status = 1,
                };
                appDbContext.Categories.Add(category1);
                appDbContext.Categories.Add(category2);
                appDbContext.Categories.Add(category3);
                appDbContext.Categories.Add(category4);
                appDbContext.Categories.Add(category5);

                appDbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var item in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            item.PropertyName, item.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
