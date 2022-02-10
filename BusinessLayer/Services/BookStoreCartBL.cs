// <copyright file="BookStoreCartBL.cs" company="Book Store Application">
//     BookStoreCartBL copyright tag.
// </copyright>

namespace Business.Services
{
    using Business.Interfaces;
    using Common.CartModel;
    using Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Book Store Cart Business Layer
    /// </summary>
    /// <seealso cref="Business.Interfaces.IBookStoreCartBL" />
    public class BookStoreCartBL : IBookStoreCartBL
    {
        /// <summary>
        /// The cart rl
        /// </summary>
        private readonly IBookStoreCartRL cartRL;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreCartBL"/> class.
        /// </summary>
        /// <param name="cartRL">The cart rl.</param>
        public BookStoreCartBL(IBookStoreCartRL cartRL)
        {
            this.cartRL = cartRL;
        }

        /// <summary>
        /// Adds the cart.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public AddCartResponse AddCart(long bookId, AddCartModel model, long jwtUserId)
        {
            try
            {
                return this.cartRL.AddCart(bookId, model, jwtUserId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the cart.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public CartResponseModel UpdateCart(long cartId, UpdateCartModel model, long jwtUserId)
        {
            try
            {
                return this.cartRL.UpdateCart(cartId, model, jwtUserId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
