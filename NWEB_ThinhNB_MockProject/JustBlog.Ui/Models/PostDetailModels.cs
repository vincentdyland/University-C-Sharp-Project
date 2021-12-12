using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustBlog.Ui.Models
{
    public class PostDetailModels
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public DateTime Created { get; set; }

        public string CategoryName { get; set; }

    }
}