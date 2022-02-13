// <copyright file="IBookStoreUserRL.cs" company="Book Store Application">
//     IBookStoreUserRL copyright tag.
// </copyright>

namespace Repository.Interfaces
{
    using Common.OrderModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Boo Store Interface
    /// </summary>
    public interface IBookStoreOrderRL
    {
        /// <summary>
        /// Adds the order.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        OrderResponse AddOrder(long bookId, AddOrderModel model, long jwtUserId);
    }
}
