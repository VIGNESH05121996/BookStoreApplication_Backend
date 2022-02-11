// <copyright file="IBookStoreAddressRL.cs" company="Book Store Application">
//     IBookStoreAddressRL copyright tag.
// </copyright>

namespace Repository.Interfaces
{
    using Common.AddressModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Book Store Address Interface
    /// </summary>
    public interface IBookStoreAddressRL
    {
        /// <summary>
        /// Adds the address.
        /// </summary>
        /// <param name="typeId">The type identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        AddressResponseModel AddAddress(long typeId, AddAdressModel model, long jwtUserId);

        /// <summary>
        /// Gets all address.
        /// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        IEnumerable<AddressResponseModel> GetAllAddress(long jwtUserId);

        /// <summary>
        /// Updates the address.
        /// </summary>
        /// <param name="addressId">The address identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        UpdateResponseModel UpdateAddress(long addressId, UpdateAddressModel model, long jwtUserId);
    }
}
