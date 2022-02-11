// <copyright file="IBookStoreFeedBackBL.cs" company="Book Store Application">
//     IBookStoreFeedBackBL copyright tag.
// </copyright>

namespace Business.Interfaces
{
    using Common.FeedBackModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Feed Back Interface
    /// </summary>
    public interface IBookStoreFeedBackBL
    {
        /// <summary>
        /// Adds the feed back.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        FeedBackResponseModel AddFeedBack(long bookId, AddFeedBackModel model, long jwtUserId);

        /// <summary>
        /// Gets all wish list.
        /// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        IEnumerable<GetAllFeedBackModel> GetAllWishList(long bookId, long jwtUserId);
    }
}
