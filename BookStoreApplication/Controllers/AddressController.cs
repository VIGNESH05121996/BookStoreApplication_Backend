﻿// <copyright file="AddressControllerr.cs" company="Book Store Application">
//     AddressController copyright tag.
// </copyright>

namespace BookStoreApplication.Controllers
{
    using Business.Interfaces;
    using Common.AddressModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Address Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        /// <summary>
        /// The address bl
        /// </summary>
        private readonly IBookStoreAddressBL addressBL;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressController"/> class.
        /// </summary>
        /// <param name="addressBL">The address bl.</param>
        public AddressController(IBookStoreAddressBL addressBL)
        {
            this.addressBL = addressBL;
        }

        /// <summary>
        /// Adds the address.
        /// </summary>
        /// <param name="typeId">The type identifier.</param>
        /// <returns></returns>
        [HttpPost("{typeId}")]
        public IActionResult AddAddress(long typeId,AddAdressModel model)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                AddressResponseModel address = addressBL.AddAddress(typeId, model, jwtUserId);
                if (address != null)
                {
                    return Ok(new { Success = true, message = "Address Added Successfully", address });
                }
                return NotFound(new { Success = false, message = "Not able to add adress since typeId is wrong" });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Gets all cart.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllAddress()
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                IEnumerable<GetAddressResponseModel> address = addressBL.GetAllAddress(jwtUserId);
                if (address == null)
                {
                    return NotFound(new { Success = false, message = "Invalid userId" });
                }

                return Ok(new { Success = true, message = "Retrived All Address ", address });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Updates the address.
        /// </summary>
        /// <param name="addressId">The address identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut("{addressId}/updateAddress")]
        public IActionResult UpdateAddress(long addressId, UpdateAddressModel model)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                UpdateResponseModel address = addressBL.UpdateAddress(addressId, model, jwtUserId);
                if (address == null)
                {
                    return NotFound(new { Success = false, message = "Invalid addressId to update" });
                }

                return Ok(new { Success = true, message = "Address Updated Successfully ", address });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Updates the type identifier.
        /// </summary>
        /// <param name="addressId">The address identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut("{addressId}/updateTypeId")]
        public IActionResult UpdateTypeId(long addressId, TypeIdUpdateModel model)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                UpdateResponseModel typeId = addressBL.UpdateTypeId(addressId, model, jwtUserId);
                if (typeId == null)
                {
                    return NotFound(new { Success = false, message = "Invalid addressId to update" });
                }

                return Ok(new { Success = true, message = "TypeId Updated Successfully ", typeId });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Deletes the address with address identifier.
        /// </summary>
        /// <param name="addressId">The address identifier.</param>
        /// <returns></returns>
        [HttpDelete("{addressId}")]
        public IActionResult DeleteAddressWithAddressId(long addressId)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                bool deleteAddress = addressBL.DeleteAddressWithAddressId(addressId, jwtUserId);
                if (deleteAddress)
                {
                    return Ok(new { Success = true, message = "Address Deleted " });
                }
                return NotFound(new { Success = false, message = "Invalid addressId" });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Get address with typeId
        /// </summary>
        /// <returns></returns>
        [HttpGet("{typeId}")]
        public IActionResult GetAddressWithTypeId(long typeId)
        {
            try
            {
                long jwtUserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                GetAddressResponseModel address = addressBL.GetAddressWithTypeId(typeId,jwtUserId);
                if (address == null)
                {
                    return NotFound(new { Success = false, message = "Invalid userId" });
                }

                return Ok(new { Success = true, message = "Retrived All Address ", address });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
