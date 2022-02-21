// <copyright file="UserController.cs" company="Book Store Application">
//     UserController copyright tag.
// </copyright>

namespace BookStoreApplication.Controllers
{
    using BusinessLayer.Interfaces;
    using Common.UserModel;
    using CommonLayer.UserModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
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
            try
            {
                if (model == null)
                {
                    return NotFound(new { Success = false, message = "Details Missing" });
                }
                SignUpResponse user = userBL.UserSignup(model);
                return Ok(new { Success = true, message = "Registration Successfull ", user });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            try
            {
                LoginResponseModel credentials = userBL.Login(model);
                if (credentials == null)
                {
                    return NotFound(new { Success = false, message = "Email or Password Not Found" });
                }
                return Ok(new { Success = true, message = "Login Successful", credentials });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Forget Password Api
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("forgetPassword")]
        public IActionResult ForgetPassword(ForgetPasswordModel model)
        {
            try
            {
                string forgetPassword = userBL.ForgetPassword(model);
                if (forgetPassword == null)
                {
                    return NotFound(new { Success = false, message = "Email not in database" });
                }
                return Ok(new { Success = true, message = "Forget Password Mail Sent" });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("resetPassword")]
        public IActionResult ResetPassword(ResetPasswordModel model)
        {
            try
            {
                string email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                bool resetPassword = userBL.ResetPassword(model, email);
                if (resetPassword)
                {
                    return Ok(new { Success = true, message = "Password Reset Successful" });
                }
                return NotFound(new { Success = false, message = "New Password not match with confirm password" });
            }
            catch (Exception ex)
            {
                return NotFound(new {message = ex.Message });
            }
        }
    }
}
