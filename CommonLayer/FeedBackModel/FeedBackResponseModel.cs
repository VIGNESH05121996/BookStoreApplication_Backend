// <copyright file="FeedBackResponseModel.cs" company="Book Store Application">
//     FeedBackResponseModel copyright tag.
// </copyright>

namespace Common.FeedBackModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Feed Back Response Model Class
    /// </summary>
    public class FeedBackResponseModel
    {
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
    }
}
