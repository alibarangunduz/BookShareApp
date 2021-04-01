using AuthAPI.Business.Abstract;
using AuthAPI.Business.Concrete;
using System;
using Xunit;

namespace AuthAPI.UnitTest
{
    public class EncryptTest
    {
        [Fact]
        public void Encrypt_Succes()
        {
            IEncryptOperation encryptOperation = new EncryptOperation();
            var result = encryptOperation.Encrypt("abc");
            Assert.Equal("979899", result);
        }
    }
}
