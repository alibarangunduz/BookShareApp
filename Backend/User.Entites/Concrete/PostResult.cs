using AuthAPI.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthAPI.Entites.Concrete
{
    public class PostResult: ResultMessage
    {
        
        public DateTime PostedDate { get; set; }
        public string Massage { get; set; }

    }
}
