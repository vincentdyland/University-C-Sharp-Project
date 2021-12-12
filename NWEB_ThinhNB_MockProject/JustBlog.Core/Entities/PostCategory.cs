using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustBlog.Core.Entities
{
    [Table("PostCategory")]
    public class PostCategory
    {
        [Key]
        [Column(Order = 0)]
        public int PostID { set; get; }


        [Key]
        [Column(Order = 1)]
        public int CategoryID { set; get; }



        [ForeignKey("PostID")]
        public Post Post { set; get; }


        [ForeignKey("CategoryID")]
        public Category Category { set; get; }
       
    }
}