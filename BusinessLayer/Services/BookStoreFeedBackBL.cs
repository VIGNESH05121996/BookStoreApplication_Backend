// <copyright file="BookStoreBookBL.cs" company="Book Store Application">
//     BookStoreBookBL copyright tag.
// </copyright>

namespace Business.Services
{
    using Business.Interfaces;
    using Common.FeedBackModel;
    using Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Book Store Feed Back of Business Layer
    /// </summary>
    public class BookStoreFeedBackBL : IBookStoreFeedBackBL
    {
        /// <summary>
        /// The feed back rl
        /// </summary>
        private readonly IBookStoreFeedBackRL feedBackRL;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreFeedBackBL"/> class.
        /// </summary>
        /// <param name="feedBackRL">The feed back rl.</param>
        public BookStoreFeedBackBL(IBookStoreFeedBackRL feedBackRL)
        {
            this.feedBackRL = feedBackRL;
        }

        /// <summary>
        /// Adds the feed back.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public FeedBackResponseModel AddFeedBack(long bookId, AddFeedBackModel model, long jwtUserId)
        {
            try
            {
                return this.feedBackRL.AddFeedBack(bookId, model, jwtUserId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets all wish list.
        /// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public IEnumerable<GetAllFeedBackModel> GetAllWishList(long bookId, long jwtUserId)
        {
            try
            {
                return this.feedBackRL.GetAllWishList(bookId, jwtUserId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
