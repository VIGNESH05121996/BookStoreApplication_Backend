// <copyright file="BookStoreBookBL.cs" company="Book Store Application">
//     BookStoreBookBL copyright tag.
// </copyright>

namespace Business.Services
{
    using Business.Interfaces;
    using Common.BookModel;
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
    }
}
