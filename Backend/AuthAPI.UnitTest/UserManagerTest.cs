using AuthAPI.Business;
using AuthAPI.Business.Abstract;
using AuthAPI.DataAccess.Abstract;
using AuthAPI.DataAccess.Concrete;
using AuthAPI.Entites;
using AuthAPI.Entites.Concrete;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AuthAPI.UnitTest
{
    public class UserManagerTest
    {
        
        
        [Fact]
        
        public async Task GetPostById()
        {

            //Arrange
           
            UserRepository userRepository = new UserRepository();
            //Act
            User user = await userRepository.GetUserById(7);

            // Assert
            Assert.Equal(7, user.Id);
        }
        [Fact]

        public async Task CreateUser()
        {

            //Arrange

            UserRepository userRepository = new UserRepository();
            //Act
            User Result = new User {Name = "baran", UserName = "ahmet", Password = "abc" };
            
            UserResult user = await userRepository.CreateUser(Result);

            // Assert
            Assert.True(user.IsSuccess);
        }


    }
}
