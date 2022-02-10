﻿// <copyright file="IBookStoreCartBL.cs" company="Book Store Application">
//     IBookStoreCartBL copyright tag.
// </copyright>

namespace Business.Interfaces
{
    using Common.CartModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Book Store Cart Interface
    /// </summary>
    public interface IBookStoreCartBL
    {
        /// <summary>
        /// Adds the cart.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        AddCartResponse AddCart(long bookId, AddCartModel model, long jwtUserId);
    }
}