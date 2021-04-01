using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuthAPI.Entites
{
    public class LoginRequest
    {
        [StringLength(50)]
        [Required]
        public string UserName { get; set; }
       
        [StringLength(30)]
        [Required]
        public string Password { get; set; }
    
        public DateTime LoginDate { get; set; }
    
    }
}
