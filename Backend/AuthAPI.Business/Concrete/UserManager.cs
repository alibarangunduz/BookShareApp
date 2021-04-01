using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AuthAPI.Business.Abstract;
using AuthAPI.DataAccess.Abstract;
using AuthAPI.DataAccess.Concrete;
using AuthAPI.Entites;
using AuthAPI.Entites.Concrete;

namespace AuthAPI.Business
{
    public class UserManager : IAuthService
    {
        private IUserRepository _userRepository;
        private readonly IEncryptOperation _encryptOperation;
        public UserManager(IUserRepository userRepository,IEncryptOperation encryptOperation)
        {
            _userRepository = userRepository;
            _encryptOperation = encryptOperation;
        }
        public async Task<UserResult> CreateUser(User user)
        {
            User FetchUser = await _userRepository.GetUserByName(user.UserName);
            if (FetchUser!=null)
            {

                return new UserResult { IsSuccess = false };
            }
            var encryptedPassword = _encryptOperation.Encrypt(user.Password);
            user.Password = encryptedPassword;
            user.CreatedDate = DateTime.Now;
            
            return await _userRepository.CreateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User> GetUserById(int id)
        {
            if (id > 0)
            {
                return await _userRepository.GetUserById(id);
            }
            throw new Exception("");
        }

        public async Task<User> GetUserByName(string UserName)
        {
            return await _userRepository.GetUserByName(UserName);
        }

        public async Task<User> UpdateUser(User user)
        {
            return await _userRepository.UpdateUser(user);
        }

        public async Task<LoginResult> LoginUser(LoginRequest loginRequest)
        {
            User FetchUser = await _userRepository.GetUserByName(loginRequest.UserName);
            if (FetchUser != null)
            {
                var encryptedPassword = _encryptOperation.Encrypt(loginRequest.Password);
                loginRequest.Password = encryptedPassword;
                loginRequest.LoginDate = DateTime.Now;
                if(encryptedPassword == FetchUser.Password)
                {
                    return new LoginResult { IsSuccess = true, LoginTime = DateTime.Now, Message = "Welcome" ,UserID = FetchUser.Id, Name = FetchUser.Name};//okey
                }
                else
                {
                    return new LoginResult { IsSuccess = false, Message = "the Password is incorrect" };
                }    
            }


            return new LoginResult { IsSuccess = false, Message = "the UserName is incorrect" };
            
        }
    }
}
