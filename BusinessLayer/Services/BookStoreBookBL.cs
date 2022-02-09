// <copyright file="BookStoreBookBL.cs" company="Book Store Application">
//     BookStoreBookBL copyright tag.
// </copyright>

namespace Business.Services
{
    using Business.Interfaces;
    using Common.BookModel;
    using Microsoft.AspNetCore.Http;
    using Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Book Store Business Layer
    /// </summary>
    /// <seealso cref="Business.Interfaces.IBookStoreBookBL" />
    public class BookStoreBookBL : IBookStoreBookBL
    {
        /// <summary>
        /// The book rl
        /// </summary>
        private IBookStoreBookRL bookRL;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreBookBL"/> class.
        /// </summary>
        /// <param name="bookRL">The book rl.</param>
        public BookStoreBookBL(IBookStoreBookRL bookRL)
        {
            this.bookRL = bookRL;
        }

        /// <summary>
        /// Users the signup.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public BookResponseModel CreateBookDetails(CreateBookModel model,long jwtUserId)
        {
            try
            {
                return this.bookRL.CreateBookDetails(model, jwtUserId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets all book.
        /// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public IEnumerable<BookResponseModel> GetAllBook(long jwtUserId)
        {
            try
            {
                return this.bookRL.GetAllBook(jwtUserId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the book with book identifier.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public BookResponseModel GetBookWithBookId(long bookId, long jwtUserId)
        {
            try
            {
                return this.bookRL.GetBookWithBookId(bookId, jwtUserId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the book details.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public BookResponseModel UpdateBookDetails(long bookId, UpdateBookModel model, long jwtUserId)
        {
            try
            {
                return this.bookRL.UpdateBookDetails(bookId,model, jwtUserId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Ratingses the update.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public BookResponseModel RatingsUpdate(long bookId, RatingsUpdateModel model, long jwtUserId)
        {
            try
            {
                return this.bookRL.RatingsUpdate(bookId, model, jwtUserId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Images the update.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="bookImage"></param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public BookResponseModel ImageUpdate(long bookId, IFormFile bookImage, long jwtUserId)
        {
            try
            {
                return this.bookRL.ImageUpdate(bookId, bookImage, jwtUserId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletets the book with book identifier.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public bool DeletetBookWithBookId(long bookId, long jwtUserId)
        {
            try
            {
                return this.bookRL.DeletetBookWithBookId(bookId, jwtUserId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
