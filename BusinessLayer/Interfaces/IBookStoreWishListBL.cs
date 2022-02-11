// <copyright file="IBookStoreWishListBL.cs" company="Book Store Application">
//     IBookStoreWishListBL copyright tag.
// </copyright>

namespace Business.Interfaces
{
    using Common.WishListModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Wish List Interface
    /// </summary>
    public interface IBookStoreWishListBL
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
