// <copyright file="AddFeedBackModel.cs" company="Book Store Application">
//     AddFeedBackModel copyright tag.
// </copyright>

namespace Common.FeedBackModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Add Feed Back Model
    /// </summary>
    public class AddFeedBackModel
    {
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
    }
}
