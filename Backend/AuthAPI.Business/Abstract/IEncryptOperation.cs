using System;
using System.Collections.Generic;
using System.Text;

namespace AuthAPI.Business.Abstract
{
    public interface IEncryptOperation
    {
        string Encrypt(string password);
    }
}
