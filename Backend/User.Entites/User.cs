using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthAPI.Entites
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string UserName { get; set; }
        [StringLength(25)]
        [Required]
        public string Name { get; set; }
        [StringLength(30)]                                     
        [Required]
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
