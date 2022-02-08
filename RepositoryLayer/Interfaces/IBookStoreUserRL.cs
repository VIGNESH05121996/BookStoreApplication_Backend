// <copyright file="IBookStoreUserRL.cs" company="Book Store Application">
//     IBookStoreUserRL copyright tag.
// </copyright>

namespace RepositoryLayer.Interfaces
{
    using Common.UserModel;
    using CommonLayer.UserModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for User Table
    /// </summary>
    public interface IBookStoreUserRL
    {
        /// <summary>
        /// Users the signup.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        SignUpResponse UserSignup(SignUpModel model);

        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        string Login(LoginModel model);

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        string ForgetPassword(ForgetPasswordModel model);

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        bool ResetPassword(ResetPasswordModel model, string email);
    }
}
