using JustBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Core.Service
{
    public class PostService
    {
        public PostService() { }

        readonly AppDbContext dbContext = new AppDbContext();


        public void DeletePost(int Id)
        {
            dbContext.Posts.Remove(dbContext.Posts.Where(P => P.Id == Id).FirstOrDefault());
            dbContext.SaveChanges();
        }

    }
}
