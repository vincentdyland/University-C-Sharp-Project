using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Core.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200, ErrorMessage = "MaxLength < 200")]
        [Required(ErrorMessage = "Name is not null")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Url must have")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} intend {1} to {2}")]
        [RegularExpression(@"^[a-z0-9-]*$", ErrorMessage = "Just [a-z0-9-]")]
        [Display(Name = "Url Display")]
        public string Slug { set; get; }
        public int Status { get; set; }
    }
}
