using AuthAPI.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthAPI.Entites.Concrete
{
    public class UserResult:ResultMessage
    {
        public DateTime CreatedDate { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string AccessToken { get; set; }

    }
}
