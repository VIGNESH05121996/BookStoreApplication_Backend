// <copyright file="LoginResponseModel.cs" company="Book Store Application">
//     LoginResponseModel copyright tag.
// </copyright>

namespace Common.UserModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Login Response Model class
    /// </summary>
    public class LoginResponseModel
    {
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the email identifier.
        /// </summary>
        /// <value>
        /// The email identifier.
        /// </value>
        public string EmailId { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>
        /// The mobile number.
        /// </value>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the JWT token.
        /// </summary>
        /// <value>
        /// The JWT token.
        /// </value>
        public string JwtToken { get; set; }
    }
}
