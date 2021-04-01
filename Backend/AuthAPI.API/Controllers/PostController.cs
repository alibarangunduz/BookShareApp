using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthAPI.Business.Abstract;
using AuthAPI.Entites;
using AuthAPI.Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private IPostService _postService;
        public PostController(IPostService postService)

        {
            _postService = postService;
        }
        /// <summary>
        /// Get ALL Posts
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Posts = await _postService.GetAllPosts();
            
            return Ok(Posts);// 200 + data
        }
        /// <summary>
        /// Create Post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("[Action]")]
        public async Task<PostResult> CreatePost([FromBody] Post post)//valid değilse zaten hiç giremeyecek
        {

            return await _postService.CreatePost(post);

        }


        /// <summary>
        /// Like Post
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[Action]")]
        public async Task<LikeResult> LikePost([FromBody] Like like)
        {

            return await _postService.AddLike(like);            
        }
        [HttpPost]
        [Route("[Action]")]
        public async Task<ReadResult> ReadPost([FromBody] Read read)
        {

            return await _postService.AddRead(read);
        
        }

    }
}
