﻿// <copyright file="IBookStoreBookBL.cs" company="Book Store Application">
//     IBookStoreBookBL copyright tag.
// </copyright>

namespace Business.Interfaces
{
    using Common.BookModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Book Store Business Layer Interface
    /// </summary>
    public interface IBookStoreBookBL
    {
        /// <summary>
        /// Users the signup.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        BookResponseModel CreateBookDetails(CreateBookModel model,long jwtUserId);

        /// <summary>
        /// Updates the book details.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        BookResponseModel UpdateBookDetails(long bookId, UpdateBookModel model, long jwtUserId);
    }
}