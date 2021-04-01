using AuthAPI.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthAPI.Entites.Concrete
{
    public class LoginResult : ResultMessage
    {
        public DateTime LoginTime { get; set; }
        public string Message { get; set; }
        public int UserID { get; set; }

        public string Name { get; set; }


    }
}
