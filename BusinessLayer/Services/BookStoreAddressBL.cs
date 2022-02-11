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

        /// <summary>
        /// Adds the address.
        /// </summary>
        /// <param name="typeId">The type identifier.</param>
        /// <param name="model"></param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets all address.
        /// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public IEnumerable<AddressResponseModel> GetAllAddress(long jwtUserId)
        {
            try
            {
                return this.addressRL.GetAllAddress(jwtUserId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the address.
        /// </summary>
        /// <param name="addressId">The address identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public UpdateResponseModel UpdateAddress(long addressId, UpdateAddressModel model, long jwtUserId)
        {
            try
            {
                return this.addressRL.UpdateAddress(addressId, model, jwtUserId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
