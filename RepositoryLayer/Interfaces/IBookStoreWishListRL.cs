// <copyright file="IBookStoreWishListRL.cs" company="Book Store Application">
//     IBookStoreWishListRL copyright tag.
// </copyright>

using Common.WishListModel;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    /// <summary>
    /// Wish List INterface
    /// </summary>
    public interface IBookStoreWishListRL
    {
        /// <summary>
        /// Adds the wish list.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        bool AddWishList(long bookId, long jwtUserId);

        /// <summary>
        /// Deletes the wish list with wish list identifier.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        bool DeleteWishListWithWishListId(long wishListId, long jwtUserId);

        /// <summary>
        /// Gets all wish list.
        /// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        IEnumerable<WishListResponseModel> GetAllWishList(long jwtUserId);
    }
}
