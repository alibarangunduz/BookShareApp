using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AuthAPI.Entites
{
    public partial class Post
    {

        public Post()
        {
            PostLikes = new HashSet<Like>();
            ReadPosts = new HashSet<Read>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostID { get; set; }

        [Required]
        public int UserID { get; set; }
        
        [StringLength(50)]
        [Required]
        public string PostHeader { get; set; }
        
        [StringLength(150)]
        [Required]
        public string PostContent { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        public DateTime PostedDate { get; set; }
        
        public ICollection<Like> PostLikes { get; set; }
        public ICollection<Read> ReadPosts { get; set; }
    }
}
