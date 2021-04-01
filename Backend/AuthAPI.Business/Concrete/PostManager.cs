using AuthAPI.Business.Abstract;
using AuthAPI.DataAccess.Abstract;
using AuthAPI.Entites;
using AuthAPI.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthAPI.Business.Concrete
{
    public class PostManager: IPostService
    {
        private readonly IPostRepository _postRepository;
        private IUserRepository _userRepository;

        public PostManager(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;


        }
        public async Task<List<Post>> GetAllPosts()
        {
            return await _postRepository.GetAllPosts();
        }

        public async Task<PostResult> CreatePost(Post post)
        {

            var isLoggedIn = await _userRepository.GetUserById(post.UserID);
            if(isLoggedIn != null)
            {
                post.PostedDate = DateTime.Now;
                return await _postRepository.CreatePost(post);
            }
            return new PostResult { IsSuccess = false , Massage = "you need to login first"};
            
        }

        public async Task<LikeResult> AddLike(Like like)
        {

            

            if (like.PostID != null && like.UserID != null)
            {
                var isLoggedIn = await _userRepository.GetUserById(like.UserID);
                var isPosted = await _postRepository.GetPostById(like.PostID);


                if (isLoggedIn != null && isPosted != null)
                {
                    return await _postRepository.AddLike(like);
                }

                return new LikeResult { IsSuccess = false, Massage = isLoggedIn == null ? "you need to login first" : "you need a post to create" };  

            }

            return new LikeResult { IsSuccess = false , Massage = "UserID and PostID must be valid" };
                

        }
        public async Task<ReadResult> AddRead(Read read)
        {



            if (read.PostID != null && read.UserID != null)
            {
                var isLoggedIn = await _userRepository.GetUserById(read.UserID);
                var isPosted = await _postRepository.GetPostById(read.PostID);


                if (isLoggedIn != null && isPosted != null)
                {
                    return await _postRepository.AddRead(read);
                }

                return new ReadResult { IsSuccess = false, Massage = isLoggedIn == null ? "you need to login first" : "you need a post to create" };

            }

            return new ReadResult { IsSuccess = false, Massage = "UserID and PostID must be valid" };


        }
    }
}
