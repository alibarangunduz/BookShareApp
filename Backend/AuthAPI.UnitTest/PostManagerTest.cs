using AuthAPI.Business.Concrete;
using AuthAPI.DataAccess.Abstract;
using AuthAPI.DataAccess.Concrete;
using AuthAPI.Entites;
using AuthAPI.Entites.Concrete;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AuthAPI.UnitTest
{
    public class PostManagerTest

    {
        
        [Fact]

        public async Task GetPostById()
        {
            PostRepository postRepository = new PostRepository();
            //Act
            Post post = await postRepository.GetPostById(9);

            // Assert
            Assert.Equal(9, post.PostID);

        }
        [Fact]

        public async Task AddRead()
        {
            PostRepository postRepository = new PostRepository();
            //Act
            var read = new Read { Name = "baran", PostID = 3, UserID = 9};
            ReadResult readResult = await postRepository.AddRead(read);

            // Assert
            Assert.False(readResult.IsSuccess);

        }
        [Fact]
        public async Task DisRead()
        {
            PostRepository postRepository = new PostRepository();
            //Act
            var read = new Read { Name = "baran" , PostID = 3, UserID = 9};
            ReadResult readResult = await postRepository.AddRead(read);

            // Assert
            Assert.True(readResult.IsSuccess);

        }
        [Fact]
        public async Task AddLike()
        {
            PostRepository postRepository = new PostRepository();
            //Act
            var like = new Like { Name = "baran", PostID = 3, UserID = 9 };
            LikeResult isLiked = await postRepository.AddLike(like);

            // Assert
            Assert.False(isLiked.IsSuccess);

        }
        [Fact]
        public async Task DisLike()
        {
            PostRepository postRepository = new PostRepository();
            //Act
            var like = new Like { Name = "baran", PostID = 3, UserID = 9 };
            LikeResult isLiked = await postRepository.AddLike(like);

            // Assert
            Assert.True(isLiked.IsSuccess);

        }
    }
}
