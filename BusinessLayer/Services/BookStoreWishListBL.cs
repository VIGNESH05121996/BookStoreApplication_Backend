// <copyright file="BookStoreWishListBLcs.cs" company="Book Store Application">
//     BookStoreWishListBLcs copyright tag.
// </copyright>

namespace Business.Services
{
    using Business.Interfaces;
    using Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Wish List of Business Layer
    /// </summary>
    public class BookStoreWishListBL : IBookStoreWishListBL
    {
        /// <summary>
        /// The wish list rl
        /// </summary>
        private readonly IBookStoreWishListRL wishListRL;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreWishListBL"/> class.
        /// </summary>
        /// <param name="wishListRL">The wish list rl.</param>
        public BookStoreWishListBL(IBookStoreWishListRL wishListRL)
        {
            this.wishListRL = wishListRL;
        }

        /// <summary>
        /// Adds the wish list.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public bool AddWishList(long bookId, long jwtUserId)
        {
            try
            {
                return this.wishListRL.AddWishList(bookId,jwtUserId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
