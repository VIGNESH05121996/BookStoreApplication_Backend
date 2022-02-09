// <copyright file="BookController.cs" company="Book Store Application">
//     BookController copyright tag.
// </copyright>

namespace BookStoreApplication.Controllers
{
    using Business.Interfaces;
    using Common.BookModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Book Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// The book bl
        /// </summary>
        private readonly IBookStoreBookBL bookBL;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookController"/> class.
        /// </summary>
        /// <param name="bookBL">The book bl.</param>
        public BookController(IBookStoreBookBL bookBL)
        {
            this.bookBL = bookBL;
        }

        /// <summary>
        /// Users the signup.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost("Book")]
        public IActionResult CreateBookDetails(CreateBookModel model)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                if (model == null)
                {
                    return NotFound(new { Success = false, message = "Not able to create book" });
                }
                BookResponseModel book = bookBL.CreateBookDetails(model,jwtUserId);
                return Ok(new { Success = true, message = "Book Created Successfully ", book });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("{bookId}")]
        public IActionResult GetBookWithBookId(long bookId)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                BookResponseModel book = bookBL.GetBookWithBookId(bookId, jwtUserId);
                if (book == null)
                {
                    return NotFound(new { Success = false, message = "Invalid BookId" });
                }

                return Ok(new { Success = true, message = "Retrived Book BooId ", book });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Updates the book details.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut("{bookId}")]
        public IActionResult UpdateBookDetails(long bookId,UpdateBookModel model)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                BookResponseModel book = bookBL.UpdateBookDetails(bookId, model, jwtUserId);
                if (book == null)
                {
                    return NotFound(new { Success = false, message = "Invalid BookId to update" });
                }
                
                return Ok(new { Success = true, message = "Book Updated Successfully ", book });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Ratingses the update.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut("{bookId}/ratings")]
        public IActionResult RatingsUpdate(long bookId, RatingsUpdateModel model)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                BookResponseModel book = bookBL.RatingsUpdate(bookId, model, jwtUserId);
                if (book == null)
                {
                    return NotFound(new { Success = false, message = "Invalid BookId to update ratings" });
                }

                return Ok(new { Success = true, message = "Book Ratings Updated Successfully ", book });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Images the update.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="bookImage">The book image.</param>
        /// <returns></returns>
        [HttpPut("{bookId}/image")]
        public IActionResult ImageUpdate(long bookId, IFormFile bookImage)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                BookResponseModel book = bookBL.ImageUpdate(bookId, bookImage, jwtUserId);
                if (book == null)
                {
                    return NotFound(new { Success = false, message = "Invalid BookId to update image" });
                }

                return Ok(new { Success = true, message = "BookImage Updated Successfully ", book });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
