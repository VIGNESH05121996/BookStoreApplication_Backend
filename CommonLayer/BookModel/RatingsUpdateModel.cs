// <copyright file="RatingsUpdateModel.cs" company="Book Store Application">
//     RatingsUpdateModel copyright tag.
// </copyright>

namespace Common.BookModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Ratings Update Model
    /// </summary>
    public class RatingsUpdateModel
    {
        /// <summary>
        /// Gets or sets the total rating.
        /// </summary>
        /// <value>
        /// The total rating.
        /// </value>
        public long TotalRating { get; set; }

        /// <summary>
        /// Gets or sets the no of people rated.
        /// </summary>
        /// <value>
        /// The no of people rated.
        /// </value>
        public long NoOfPeopleRated { get; set; }
    }
}
