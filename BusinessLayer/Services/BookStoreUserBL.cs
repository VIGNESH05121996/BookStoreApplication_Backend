// <copyright file="BookStoreUserBL.cs" company="Book Store Application">
//     BookStoreUserBL copyright tag.
// </copyright>

namespace BusinessLayer.Services
{
    using BusinessLayer.Interfaces;
    using Common.UserModel;
    using CommonLayer.UserModel;
    using RepositoryLayer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Business Layer For UserTable
    /// </summary>
    /// <seealso cref="BusinessLayer.Interfaces.IBookStoreUserBL" />
    public class BookStoreUserBL : IBookStoreUserBL
    {
        /// <summary>
        /// The user rl
        /// </summary>
        private IBookStoreUserRL userRL;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreUserBL"/> class.
        /// </summary>
        /// <param name="userRL">The user rl.</param>
        public BookStoreUserBL(IBookStoreUserRL userRL)
        {
            this.userRL = userRL;
        }

        /// <summary>
        /// Users the signup.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public SignUpResponse UserSignup(SignUpModel model)
        {
            try
            {
                return this.userRL.UserSignup(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public LoginResponseModel Login(LoginModel model)
        {
            try
            {
                return this.userRL.Login(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public string ForgetPassword(ForgetPasswordModel model)
        {
            try
            {
                return this.userRL.ForgetPassword(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public bool ResetPassword(ResetPasswordModel model, string email)
        {
            try
            {
                return this.userRL.ResetPassword(model, email);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
