// <copyright file="AddOrderModel.cs" company="Book Store Application">
//      AddOrderModel copyright tag.
// </copyright>

namespace Common.OrderModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Add order model class
    /// </summary>
    public class AddOrderModel
    {
        /// <summary>
        /// Gets or sets the address identifier.
        /// </summary>
        /// <value>
        /// The address identifier.
        /// </value>
        public long AddressId { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public long Quantity { get; set; }
    }
}
