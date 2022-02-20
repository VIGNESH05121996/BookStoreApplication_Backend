// <copyright file="GetAllOrdersResponseModel.cs" company="Book Store Application">
//      GetAllOrdersResponseModel copyright tag.
// </copyright>

namespace Common.OrderModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Get All Orders Response Model
    /// </summary>
    public class GetAllOrdersResponseModel
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public long OrderId { get; set; }
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

        /// <summary>
        /// Gets or sets the address identifier.
        /// </summary>
        /// <value>
        /// The address identifier.
        /// </value>
        public long AddressId { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public long TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public long Quantity { get; set; }
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
        /// Gets or sets the book image.
        /// </summary>
        /// <value>
        /// The book image.
        /// </value>
        public string BookImage { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public string BookDetails { get; set; }

        /// <summary>
        /// Gets or sets the type identifier.
        /// </summary>
        /// <value>
        /// The type identifier.
        /// </value>
        public long TypeId { get; set; }
        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the full address.
        /// </summary>
        /// <value>
        /// The full address.
        /// </value>
        public string FullAddress { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
    }
}
