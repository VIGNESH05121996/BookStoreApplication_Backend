// <copyright file="AddressControllerr.cs" company="Book Store Application">
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
                    return Ok(new { Success = true, message = "Book added to wish list", address });
                }
                return NotFound(new { Success = false, message = "Not able to Book to wish list since bookId is wrong" });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
