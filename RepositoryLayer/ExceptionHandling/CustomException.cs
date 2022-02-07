// <copyright file="CustomException.cs" company="Book Store Application">
//     CustomException copyright tag.
// </copyright>

namespace Repository.ExceptionHandling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// CustomException class inherited from Exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class CustomException : Exception
    {
        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public HttpStatusCode Status { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="msg">The MSG.</param>
        public CustomException(HttpStatusCode status, string msg) : base(msg)
        {
            Status = status;
        }
    }
}
