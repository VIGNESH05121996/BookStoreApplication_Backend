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
            return this.userRL.UserSignup(model);
        }

        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public string Login(LoginModel model)
        {
            return this.userRL.Login(model);
        }

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public string ForgetPassword(ForgetPasswordModel model)
        {
            return this.userRL.ForgetPassword(model);
        }
    }
}
