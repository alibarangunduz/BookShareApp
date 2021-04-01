using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthAPI.Business;
using AuthAPI.Business.Abstract;
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public AuthController(IAuthService authService)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _authService = authService;
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
        public async Task<UserResult> CreateUser([FromBody] User user)//valid değilse zaten hiç giremeyecek
        {
            
            return await _authService.CreateUser(user);
           
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
