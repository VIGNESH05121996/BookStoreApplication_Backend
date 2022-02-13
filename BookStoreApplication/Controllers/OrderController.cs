// <copyright file="OrderController.cs" company="Book Store Application">
//     OrderController copyright tag.
// </copyright>

namespace BookStoreApplication.Controllers
{
    using Business.Interfaces;
    using Common.OrderModel;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Order Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        /// <summary>
        /// The order bl
        /// </summary>
        private readonly IBookStoreOrderBL orderBL;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// </summary>
        /// <param name="orderBL">The order bl.</param>
        public OrderController(IBookStoreOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }

        /// <summary>
        /// Adds the order.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost("{bookId}")]
        public IActionResult AddOrder(long bookId, AddOrderModel model)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                OrderResponse order = orderBL.AddOrder(bookId, model, jwtUserId);
                if (order != null)
                {
                    return Ok(new { Success = true, message = "Order Placed Successfully", order });
                }
                return NotFound(new { Success = false, message = "Order quantity is more than available quantity. Try after some times" });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Get All Orders controller
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                IEnumerable<OrderResponse> allOrders = orderBL.GetAllOrders(jwtUserId);
                if (allOrders == null)
                {
                    return NotFound(new { Success = false, message = "Invalid User Id" });
                }

                return Ok(new { Success = true, message = "Retrived All Orders ", allOrders });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
