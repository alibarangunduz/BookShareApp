using AuthAPI.Entites;
using AuthAPI.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthAPI.Business.Abstract
{
    public interface IPostService
    {
        Task<PostResult> CreatePost(Post post);
        Task<List<Post>> GetAllPosts();
        Task<LikeResult> AddLike(Like like);

        Task<ReadResult> AddRead(Read read);

    }
}
