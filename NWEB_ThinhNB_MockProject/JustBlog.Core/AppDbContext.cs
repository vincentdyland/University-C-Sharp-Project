using JustBlog.Core.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Core
{
    
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
        public Post PostDetail(int id)
        {
            return Posts.Find(id);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PostCategory>().HasKey(o => new { o.PostID, o.CategoryID });
        }
    }
}
