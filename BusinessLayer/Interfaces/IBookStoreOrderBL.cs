// <copyright file="IBookStoreOrderBL.cs" company="Book Store Application">
//     IBookStoreOrderBL copyright tag.
// </copyright>

namespace Business.Interfaces
{
    using Common.OrderModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Book Store Order Interface
    /// </summary>
    public interface IBookStoreOrderBL
    {
        /// <summary>
        /// Adds the order.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        OrderResponse AddOrder(long bookId, AddOrderModel model, long jwtUserId);

        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        IEnumerable<OrderResponse> GetAllOrders(long jwtUserId);
    }
}
