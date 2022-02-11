// <copyright file="WishListController.cs" company="Book Store Application">
//     WishListController copyright tag.
// </copyright>

namespace BookStoreApplication.Controllers
{
    using Business.Interfaces;
    using Common.FeedBackModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Feed Back Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        /// <summary>
        /// The feed back bl
        /// </summary>
        private readonly IBookStoreFeedBackBL feedBackBL;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedBackController"/> class.
        /// </summary>
        /// <param name="feedBackBL">The feed back bl.</param>
        public FeedBackController(IBookStoreFeedBackBL feedBackBL)
        {
            this.feedBackBL = feedBackBL;
        }

        /// <summary>
        /// Adds the feed back.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost("{bookId}")]
        public IActionResult AddFeedBack(long bookId, AddFeedBackModel model)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                FeedBackResponseModel feedBackList = feedBackBL.AddFeedBack(bookId, model, jwtUserId);
                if (feedBackList != null)
                {
                    return Ok(new { Success = true, message = "Feed Back Added", feedBackList });
                }
                return NotFound(new { Success = false, message = "Not able to Add Feed Back since bookId is wrong" });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Gets all feed back.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>
        [HttpGet("{bookId}")]
        public IActionResult GetAllFeedBack(long bookId)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                IEnumerable<GetAllFeedBackModel> feedBacks = feedBackBL.GetAllWishList(bookId, jwtUserId);
                if (feedBacks == null)
                {
                    return NotFound(new { Success = false, message = "Invalid Book Id" });
                }

                return Ok(new { Success = true, message = "Retrived All Feed back of Book ", feedBacks });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
