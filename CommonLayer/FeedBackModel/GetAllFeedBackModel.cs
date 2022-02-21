// <copyright file="GetAllFeedBackModel.cs" company="Book Store Application">
//     GetAllFeedBackModel copyright tag.
// </copyright>

namespace Common.FeedBackModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Get All Feed Back Response Model
    /// </summary>
    public class GetAllFeedBackModel
    {
        /// <summary>
        /// Gets or sets the feed back identifier.
        /// </summary>
        /// <value>
        /// The feed back identifier.
        /// </value>
        public long FeedBackId { get; set; }
        /// <summary>
        /// Gets or sets the book identifier.
        /// </summary>
        /// <value>
        /// The book identifier.
        /// </value>
        public long BookId { get; set; }

        /// <summary>
        /// Gets or sets the feed back.
        /// </summary>
        /// <value>
        /// The feed back.
        /// </value>
        public string FeedBack { get; set; }

        /// <summary>
        /// Gets or sets the ratings.
        /// </summary>
        /// <value>
        /// The ratings.
        /// </value>
        public long Ratings { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get; set; }
    }
}
