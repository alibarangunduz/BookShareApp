using AuthAPI.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthAPI.Entites.Concrete
{
    public class GetAllPosts:ResultMessage
    {
        public int PostID { get; set; }
        public int UserID { get; set; }
        public string PostHeader { get; set; }
        public string PostContent { get; set; }
        public string Name { get; set; }
        public DateTime PostedDate { get; set; }

        public Like [] Likes { get; set; }
        public Read [] Reads { get; set; }

    }
}
