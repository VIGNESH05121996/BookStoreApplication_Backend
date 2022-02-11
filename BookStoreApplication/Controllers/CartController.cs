// <copyright file="CartController.cs" company="Book Store Application">
//     CartController copyright tag.
// </copyright>

namespace BookStoreApplication.Controllers
{
    using Business.Interfaces;
    using Common.CartModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Cart Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        /// <summary>
        /// The cart bl
        /// </summary>
        private readonly IBookStoreCartBL cartBL;

        /// <summary>
        /// Cart Controller Constructor
        /// </summary>
        /// <param name="cartBL"></param>
        public CartController(IBookStoreCartBL cartBL)
        {
            this.cartBL = cartBL;
        }

        /// <summary>
        /// Add Cart Api
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("{bookId}")]
        public IActionResult AddCart(long bookId,AddCartModel model)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                AddCartResponse cart = cartBL.AddCart(bookId, model, jwtUserId);
                if (cart == null)
                {
                    return NotFound(new { Success = false, message = "Not able to Book to cart since bookId is wrong" });
                }
                return Ok(new { Success = true, message = "Book added to cart", cart });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Gets all cart.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllCart()
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                IEnumerable<CartResponseModel> cart = cartBL.GetAllCart(jwtUserId);
                if (cart == null)
                {
                    return NotFound(new { Success = false, message = "Invalid Cart" });
                }

                return Ok(new { Success = true, message = "Retrived All Cart ", cart });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Updates the cart.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut("{cartId}")]
        public IActionResult UpdateCart(long cartId, UpdateCartModel model)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                CartResponseModel cart = cartBL.UpdateCart(cartId, model, jwtUserId);
                if (cart == null)
                {
                    return NotFound(new { Success = false, message = "Invalid cartId to update" });
                }

                return Ok(new { Success = true, message = "Cart Updated Successfully ", cart });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Deletets the book with book identifier.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>
        [HttpDelete("{cartId}")]
        public IActionResult DeleteCartWithCartId(long cartId)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                bool deleteBook = cartBL.DeleteCartWithCartId(cartId, jwtUserId);
                if (deleteBook)
                {
                    return Ok(new { Success = true, message = "Cart Deleted " });
                }
                return NotFound(new { Success = false, message = "Invalid CartId" });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
