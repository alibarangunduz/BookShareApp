using AuthAPI.Entites;
using AuthAPI.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AuthAPI.Business.Abstract
{
    public interface IAuthService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);

        Task<User> GetUserByName(string name);
        Task<UserResult> CreateUser(User user);

        Task<LoginResult> LoginUser(LoginRequest loginRequest);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
