using JustBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustBlog.Ui.Models
{
    public class CreatePostModel : Post
    {
        public List<PostCategory> PostCategories { get; set; }
    }
}