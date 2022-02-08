// <copyright file="ResetPasswordModel.cs" company="Book Store Application">
//     ResetPasswordModel copyright tag.
// </copyright>

namespace Common.UserModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Reset Password Model
    /// </summary>
    public class ResetPasswordModel
    {
        /// <summary>
        /// Creates new password.
        /// </summary>
        /// <value>
        /// The new password.
        /// </value>
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>
        /// The confirm password.
        /// </value>
        public string ConfirmPassword { get; set; }
    }
}
