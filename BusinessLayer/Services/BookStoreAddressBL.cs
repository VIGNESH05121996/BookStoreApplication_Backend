// <copyright file="BookStoreAddressBL.cs" company="Book Store Application">
//     BookStoreAddressBL copyright tag.
// </copyright>

namespace Business.Services
{
    using Business.Interfaces;
    using Common.AddressModel;
    using Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Book Store Address Business Layer
    /// </summary>
    public class BookStoreAddressBL : IBookStoreAddressBL
    {
        /// <summary>
        /// The address rl
        /// </summary>
        private readonly IBookStoreAddressRL addressRL;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreAddressBL"/> class.
        /// </summary>
        /// <param name="addressRL">The address rl.</param>
        public BookStoreAddressBL(IBookStoreAddressRL addressRL)
        {
            this.addressRL = addressRL;
        }

        public AddressResponseModel AddAddress(long typeId, AddAdressModel model, long jwtUserId)
        {
            try
            {
                return this.addressRL.AddAddress(typeId, model, jwtUserId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
