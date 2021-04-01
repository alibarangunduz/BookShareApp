using AuthAPI.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthAPI.Entites.Concrete
{
    public class ReadResult: ResultMessage

    {
        public string Massage { get; set; }
    }
}
