using AuthAPI.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthAPI.Business.Concrete
{
    public class EncryptOperation : IEncryptOperation
    {
        public string Encrypt(string password)
        {
            var passwordChars = password.ToCharArray();
            StringBuilder passwordBuilder = new StringBuilder();
            foreach (var passwordChar in passwordChars)
            {
                passwordBuilder.Append((int)passwordChar);
            }
            return passwordBuilder.ToString();
        }
    }
}
