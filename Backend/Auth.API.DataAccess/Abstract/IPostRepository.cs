using AuthAPI.Entites;
using AuthAPI.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthAPI.DataAccess.Abstract
{
    public interface IPostRepository
    {
        public Task<PostResult> CreatePost(Post post);
        public Task<List<Post>> GetAllPosts();

        public Task<LikeResult> AddLike(Like like);

        public Task<ReadResult> AddRead(Read read);

        public Task<Post> GetPostById(int id);
    }
}
