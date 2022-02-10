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
        [HttpPost("{bookId}/cart")]
        public IActionResult AddCart(long bookId,AddCartModel model)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                AddCartResponse book = cartBL.AddCart(bookId, model, jwtUserId);
                if (book == null)
                {
                    return NotFound(new { Success = false, message = "Not able to Book to cart since bookId is wrong" });
                }
                return Ok(new { Success = true, message = "Book added to cart", book });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("{cartId}")]
        public IActionResult UpdateCart(long cartId, UpdateCartModel model)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                CartResponseModel book = cartBL.UpdateCart(cartId, model, jwtUserId);
                if (book == null)
                {
                    return NotFound(new { Success = false, message = "Invalid cartId to update" });
                }

                return Ok(new { Success = true, message = "Cart Updated Successfully ", book });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
