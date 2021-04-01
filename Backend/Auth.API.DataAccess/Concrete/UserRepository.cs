using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AuthAPI.DataAccess.Abstract;
using AuthAPI.Entites;
using AuthAPI.Entites.Concrete;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        public async Task<UserResult> CreateUser(User user)
        {
            using var AuthDbContext = new AuthDbContext();
            AuthDbContext.Users.Add(user);
            await AuthDbContext.SaveChangesAsync();
            return new UserResult { IsSuccess = true, CreatedDate = DateTime.Now , UserID = user.Id, Name = user.Name};
        }

        public async Task DeleteUser(int id)
        {
            using (var AuthDbContext = new AuthDbContext())
            {
                var deletedHotel = await GetUserById(id);
                AuthDbContext.Users.Remove(deletedHotel);
                await AuthDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            using(var AuthDbContext = new AuthDbContext())
            {
                return await AuthDbContext.Users.ToListAsync();
            }
        }

        public async Task<User> GetUserByName(string UserName)
        {
            using (var AuthDbContext = new AuthDbContext())
            {
                
                return await AuthDbContext.Users.FirstOrDefaultAsync(x => x.UserName == UserName);
            }
        }

        public async Task<User> GetUserById(int id)
        {
            using (var AuthDbContext = new AuthDbContext())
            {
                return await AuthDbContext.Users.FindAsync(id);
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            using (var AuthDbContext = new AuthDbContext())
            {
                AuthDbContext.Users.Update(user);
                await AuthDbContext.SaveChangesAsync();
                return user;
            }
        }

        
    }
}
