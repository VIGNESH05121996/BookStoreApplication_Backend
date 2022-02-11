// <copyright file="WishListController.cs" company="Book Store Application">
//     WishListController copyright tag.
// </copyright>

namespace BookStoreApplication.Controllers
{
    using Business.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Wish List Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        /// <summary>
        /// The wish list bl
        /// </summary>
        private readonly IBookStoreWishListBL wishListBL;

        /// <summary>
        /// Initializes a new instance of the <see cref="WishListController"/> class.
        /// </summary>
        /// <param name="wishListBL">The wish list bl.</param>
        public WishListController(IBookStoreWishListBL wishListBL)
        {
            this.wishListBL = wishListBL;
        }

        /// <summary>
        /// Adds the wish list.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>
        [HttpPost("{bookId}")]
        public IActionResult AddWishList(long bookId)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                bool wishList = wishListBL.AddWishList(bookId, jwtUserId);
                if (wishList)
                {
                    return Ok(new { Success = true, message = "Book added to wish list"});
                }
                return NotFound(new { Success = false, message = "Not able to Book to wish list since bookId is wrong" });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Deletes the wish list with wish list identifier.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <returns></returns>
        [HttpDelete("{wishListId}")]
        public IActionResult DeleteWishListWithWishListId(long wishListId)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                bool deleteWishList = wishListBL.DeleteWishListWithWishListId(wishListId, jwtUserId);
                if (deleteWishList)
                {
                    return Ok(new { Success = true, message = "WishList Deleted " });
                }
                return NotFound(new { Success = false, message = "Invalid WishListId" });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
