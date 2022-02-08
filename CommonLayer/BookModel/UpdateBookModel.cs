// <copyright file="UpdateBookModel.cs" company="Book Store Application">
//     UpdateBookModel copyright tag.
// </copyright>

namespace Common.BookModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Update Book Model
    /// </summary>
    public class UpdateBookModel
    {
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
    }
}
