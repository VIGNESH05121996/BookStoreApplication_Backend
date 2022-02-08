// <copyright file="UserController.cs" company="Book Store Application">
//     UserController copyright tag.
// </copyright>

namespace BookStoreApplication.Controllers
{
    using BusinessLayer.Interfaces;
    using Common.UserModel;
    using CommonLayer.UserModel;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// User Controller for signup,login,forget and reset password
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The user bl
        /// </summary>
        private readonly IBookStoreUserBL userBL;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userBL">The user bl.</param>
        public UserController(IBookStoreUserBL userBL)
        {
            this.userBL = userBL;
        }

        /// <summary>
        /// Users the signup.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost("signup")]
        public IActionResult UserSignup(SignUpModel model)
        {
            if (model == null)
            {
                return NotFound(new { Success = false, message = "Details Missing" });
            }
            SignUpResponse user = userBL.UserSignup(model);
            return Ok(new { Success = true, message = "Registration Successfull ", user });
        }

        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            string credentials = userBL.Login(model);
            if (credentials == null)
            {
                return NotFound(new { Success = false, message = "Email or Password Not Found" });
            }
            return Ok(new { Success = true, message = "Login Successful", jwtToken = credentials });
        }

        /// <summary>
        /// Forget Password Api
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("ForgetPassword")]
        public IActionResult ForgetPassword(ForgetPasswordModel model)
        {
            string forgetPassword = userBL.ForgetPassword(model);
            if (forgetPassword == null)
            {
                return NotFound(new { Success = false, message = "Email not in database" });
            }
            return Ok(new { Success = true, message = "Forget Password Mail Sent" });
        }
    }
}
