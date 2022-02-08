// <copyright file="BookValidationModel.cs" company="Book Store Application">
//     BookValidationModel copyright tag.
// </copyright>

namespace Common.BookModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Book Validation Model Class
    /// </summary>
    public class BookValidationModel
    {
        /// <summary>
        /// Gets or sets the book identifier.
        /// </summary>
        /// <value>
        /// The book identifier.
        /// </value>
        public long BookId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public long UserId { get; set; }
    }
}
