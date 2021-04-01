using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AuthAPI.Entites
{
    public class Read
    {
        [Required]
        public int PostID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReadID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
