// <copyright file="BookResponseModel.cs" company="Book Store Application">
//     BookResponseModel copyright tag.
// </copyright>

namespace Common.BookModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Book Response Model
    /// </summary>
    public class BookResponseModel
    {
        /// <summary>
        /// Gets or sets the book identifier.
        /// </summary>
        /// <value>
        /// The book identifier.
        /// </value>
        public long BookId { get; set; }

        /// <summary>
        /// Gets or sets the name of the book.
        /// </summary>
        /// <value>
        /// The name of the book.
        /// </value>
        public string BookName { get; set; }

        /// <summary>
        /// Gets or sets the book author.
        /// </summary>
        /// <value>
        /// The book author.
        /// </value>
        public string BookAuthor { get; set; }

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

        /// <summary>
        /// Gets or sets the original price.
        /// </summary>
        /// <value>
        /// The original price.
        /// </value>
        public long OriginalPrice { get; set; }

        /// <summary>
        /// Gets or sets the discount price.
        /// </summary>
        /// <value>
        /// The discount price.
        /// </value>
        public long DiscountPrice { get; set; }

        /// <summary>
        /// Gets or sets the book image.
        /// </summary>
        /// <value>
        /// The book image.
        /// </value>
        public string BookImage { get; set; }

        /// <summary>
        /// Gets or sets the book quantity.
        /// </summary>
        /// <value>
        /// The book quantity.
        /// </value>
        public long BookQuantity { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public string BookDetails { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public long UserId { get; set; }
    }
}
