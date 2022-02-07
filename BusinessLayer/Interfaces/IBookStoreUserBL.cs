// <copyright file="IBookStoreUserBL.cs" company="Book Store Application">
//     IBookStoreUserBL copyright tag.
// </copyright>

namespace BusinessLayer.Interfaces
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
    public interface IBookStoreUserBL
    {
        /// <summary>
        /// Users the signup.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        SignUpResponse UserSignup(SignUpModel model);
    }
}
