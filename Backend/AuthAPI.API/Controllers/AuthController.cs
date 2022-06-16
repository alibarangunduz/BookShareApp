using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthAPI.Business;
using AuthAPI.Business.Abstract;
using AuthAPI.Business.Services.Authenticators;
using AuthAPI.Business.Services.TokenGenerators;
using AuthAPI.Entites;
using AuthAPI.Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;


namespace AuthAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private readonly Authenticator _authenticator;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public AuthController(IAuthService authService, Authenticator authenticator)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _authService = authService;
            _authenticator = authenticator;
        }

        
        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]//api/Hotels/gethotelbyid/2
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _authService.GetUserById(id);
            if (user != null)
            {
                return Ok(user);// 200+ datum
            }
            return NotFound(); //404
        }
        
       /// <summary>
       /// Get UserBy Name
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
        [HttpGet]
        [Route("[action]/{name}")]//api/Hotels/gethotelbyname/something
        public async Task<IActionResult> GetUserByName(string name)

        {

            var user = await _authService.GetUserByName(name);
            if (user != null)
            {
                return Ok(user); //200 + datum
            }
            return NotFound();
        }

        /// <summary>
        /// Create an User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> CreateUser([FromBody] User user)//valid değilse zaten hiç giremeyecek
        {
            var response = await _authService.CreateUser(user);
            var accessToken = await _authenticator.Authenticate(response);
            if(accessToken == null)
            {
                return Unauthorized();
            }
            UserResult userResult = new UserResult();
            userResult.AccessToken = accessToken;

            return Ok(accessToken);


        }
        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("[Action]")]
        public async Task<LoginResult> LoginUser([FromBody] LoginRequest loginRequest)//valid değilse zaten hiç giremeyecek
        {
            return await _authService.LoginUser(loginRequest);
          
        }
        /// <summary>
        /// Update the User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            if (await _authService.GetUserById(user.Id) != null)
            {
                return Ok(await _authService.UpdateUser(user));//200 + data
            }
            return NotFound();
        }
        /// <summary>
        /// Delete the User
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("[Action]/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (await _authService.GetUserById(id) != null)
            {
                await _authService.DeleteUser(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
