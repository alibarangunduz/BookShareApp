using System;
using AuthAPI.Entites;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.DataAccess
{
    public class AuthDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=..\\SQLEXPRESS; Database=*;uid=*;pwd=*;");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Read> Reads { get; set; }
    }
}
