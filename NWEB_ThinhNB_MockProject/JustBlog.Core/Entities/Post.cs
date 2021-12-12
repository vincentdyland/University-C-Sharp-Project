﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Core.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(200, ErrorMessage = "MaxLength < 200")]
        [Required(ErrorMessage = "Title must have")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Content must have")]
        public string Content { get; set; }


        [Required(ErrorMessage = "Description must have")]
        public string Description { get; set; }


        [Display(Name = "Slug", Prompt = "if Url is empty, automatically generated by Title")]
        [RegularExpression(@"^[a-z0-9-]*$", ErrorMessage = "Just [a-z0-9-]")]
        public string Slug { set; get; }


        public string AuthorId { set; get; }

        public DateTime DateCreated { set; get; }

        public DateTime DateUpdated { set; get; }

        public int Status { get; set; }
    }
}
