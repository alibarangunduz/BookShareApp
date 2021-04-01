using AuthAPI.DataAccess.Abstract;
using AuthAPI.Entites;
using AuthAPI.Entites.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthAPI.DataAccess.Concrete
{
    public class PostRepository : IPostRepository
    {

        
        public async Task<PostResult> CreatePost(Post post)
        {
            using var AuthDbContext = new AuthDbContext();
            AuthDbContext.Post.Add(post);
            await AuthDbContext.SaveChangesAsync();
            return new PostResult { IsSuccess = true, PostedDate = DateTime.Now , Massage = "successfully created" };

        }

        public async Task<LikeResult> AddLike(Like like)
        {

            using (var AuthDbContext = new AuthDbContext())
            {
                var isLiked = AuthDbContext.Likes.Where(X => X.PostID == like.PostID && X.UserID == like.UserID).ToList();

                if (isLiked.Count == 0)//daha önceden beğenmediyse beğen.
                {
                    AuthDbContext.Likes.Add(like);
                    await AuthDbContext.SaveChangesAsync();
                    return new LikeResult { IsSuccess = true, Massage = "Successfully Liked"};
                    }


                AuthDbContext.Likes.Remove(isLiked[0]);//daha önceden beğendisye beğenisini kaldır.
                await AuthDbContext.SaveChangesAsync();
                return new LikeResult { IsSuccess = false, Massage = "Successfully Disliked" };

            }

        }
        public async Task<ReadResult> AddRead(Read read)
        {

            using var AuthDbContext = new AuthDbContext();
            var isRead = AuthDbContext.Reads.Where(X => X.PostID == read.PostID && X.UserID == read.UserID).ToList();

            if (isRead.Count == 0)//daha önceden Okumadı ise beğen.
            {

                AuthDbContext.Reads.Add(read);
                await AuthDbContext.SaveChangesAsync();
                return new ReadResult { IsSuccess = true, Massage = "Successfully Read" };
            }


            AuthDbContext.Reads.Remove(isRead[0]);//daha önceden beğendisye beğenisini kaldır.
            await AuthDbContext.SaveChangesAsync();
            return new ReadResult { IsSuccess = false, Massage = "Successfully DisRead" };

        }
        public async Task<List<Post>> GetAllPosts()
        {
            using (var AuthDbContext = new AuthDbContext())
            {

                var post = await AuthDbContext.Post.Include(p => p.PostLikes).ToListAsync();
                post = await AuthDbContext.Post.Include(p => p.ReadPosts).ToListAsync();
                return post;
            }
        }

        public async Task<Post> GetPostById(int id)
        {
            using (var AuthDbContext = new AuthDbContext())
            {
                return await AuthDbContext.Post.FindAsync(id);
            }
        }


    }
}
