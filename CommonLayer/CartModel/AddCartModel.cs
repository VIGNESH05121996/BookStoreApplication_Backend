// <copyright file="AddCartModel.cs" company="Book Store Application">
//     AddCartModel copyright tag.
// </copyright>

namespace Common.CartModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Add Cart Model
    /// </summary>
    public class AddCartModel
    {
        /// <summary>
        /// Gets or sets the book quantity.
        /// </summary>
        /// <value>
        /// The book quantity.
        /// </value>
        public long Quantity { get; set; }
    }
}
