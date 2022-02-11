// <copyright file="IBookStoreWishListRL.cs" company="Book Store Application">
//     IBookStoreWishListRL copyright tag.
// </copyright>

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
    }
}
