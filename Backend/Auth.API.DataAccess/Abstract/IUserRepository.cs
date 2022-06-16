using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AuthAPI.Entites;
using AuthAPI.Entites.Concrete;

namespace AuthAPI.DataAccess.Abstract
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllUsers();
        public Task<User> GetUserById(int id);

        public Task<User> GetUserByName(string UserName);
        public Task<User> CreateUser(User user);
        public Task<User> UpdateUser(User user);
        public Task DeleteUser(int id);
    }
}
