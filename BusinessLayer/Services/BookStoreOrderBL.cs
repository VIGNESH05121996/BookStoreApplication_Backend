// <copyright file="BookStoreOrderBL.cs" company="Book Store Application">
//     BookStoreOrderBL copyright tag.
// </copyright>

namespace Business.Services
{
    using Business.Interfaces;
    using Common.OrderModel;
    using Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Book Store Order Business Layer
    /// </summary>
    public class BookStoreOrderBL : IBookStoreOrderBL
    {
        /// <summary>
        /// The order rl
        /// </summary>
        private readonly IBookStoreOrderRL orderRL;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreOrderBL"/> class.
        /// </summary>
        /// <param name="orderRL">The order rl.</param>
        public BookStoreOrderBL(IBookStoreOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }

        /// <summary>
        /// Adds the order.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public OrderResponse AddOrder(long bookId, AddOrderModel model, long jwtUserId)
        {
            try
            {
                return this.orderRL.AddOrder(bookId, model, jwtUserId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public IEnumerable<OrderResponse> GetAllOrders(long jwtUserId)
        {
            try
            {
                return this.orderRL.GetAllOrders(jwtUserId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
