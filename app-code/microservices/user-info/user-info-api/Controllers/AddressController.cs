/*----------------------------------------------------------------------------*/
/* Source File:   ADDRESSCONTROLLER.CS                                        */
/* Description:   MVC Controller to manage AddressData information.           */
/* Author:        Carlos Adolfo Ortiz Quirós (COQ)                            */
/* Date:          Feb.07/2018                                                 */
/* Last Modified: Feb.12/2018                                                 */
/* Version:       1.1                                                         */
/* Copyright (c), 2018 CSoftZ.                                                */
/*----------------------------------------------------------------------------*/
/*-----------------------------------------------------------------------------
 History
 Feb.07/2018 COQ  File created.
 -----------------------------------------------------------------------------*/

using System.Collections.Generic;
using CSoftZ.User.Info.Api.Domain;
using CSoftZ.User.Info.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSoftZ.User.Info.Api.Controllers
{
    /// <summary>
    /// MVC Controller to manage AddressData information.
    /// </summary>
    [Route("userinfo/api/v1/[controller]")]
    public class AddressController : Controller
    {
        private readonly IAddressService addressService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CSoftZ.User.Info.Api.Controllers.AddressController"/> class.
        /// </summary>
        /// <param name="addressService">Address service.</param>
        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        /// <summary>
        /// Responds to the URL: GET /userinfo/api/v1/address
        /// Retrieves all records.
        /// </summary>
        /// <returns>A list of all addresses</returns>
        [HttpGet]
        public List<AddressData> GetAll()
        {
            return addressService.GetAll();
        }

        /// <summary>
        /// Responds to the URL: GET /userinfo/api/v1/address/{id}.
        /// Where {id} is a placeholder for the id to look for.
        /// </summary>
        /// <returns>A HTTP Not Found or object found</returns>
        /// <param name="id">Identifier to look up.</param>
        [HttpGet("{id}", Name = "GetAddressData")]
        public IActionResult GetById(long id)
        {
            var item = addressService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        /// <summary>
        /// Responds to the URL: POST /userinfo/api/v1/address
        /// Create a record in storage.
        /// </summary>
        /// <returns>The created record and HTTP status created</returns>
        /// <param name="item">Record information to create.</param>
        [HttpPost]
        public IActionResult Create([FromBody] UserDataCommand item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            AddressData addressData = new AddressData();
            addressData.Name = item.AddressName;
            addressData.CityData = new CityData();
            addressData.CityData.Id = item.IdCity;
            addressData.CityData.Name = item.CityName;
            addressData.CityData.StateData = new StateData();
            addressData.CityData.StateData.Id = item.IdState;
            addressData.CityData.StateData.Name = item.StateName;
            addressData.CityData.StateData.CountryData = new CountryData();
            addressData.CityData.StateData.CountryData.Id = item.IdCountry;
            addressData.CityData.StateData.CountryData.Name = item.CountryName;

            var info = addressService.Create(addressData);
            return CreatedAtRoute("GetAddressData", new { id = info.Id }, info);
        }

        /// <summary>
        /// Responds to URL: PUT /userinfo/api/v1/address/{id}.
        /// Where {id} is a placeholder for the id to look for.
        /// </summary>
        /// <returns>A bad request if parameters are not corrrect.
        /// A not found record or the updated record.
        /// </returns>
        /// <param name="id">Identifier to update.</param>
        /// <param name="item">Record information to update.</param>
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] UserDataCommand item)
        {
            if (item == null || item.IdAddress != id)
            {
                return BadRequest();
            }

            AddressData addressData = new AddressData();
            addressData.Id = item.IdAddress;
            addressData.Name = item.AddressName;
            addressData.CityData = new CityData();
            addressData.CityData.Id = item.IdCity;
            addressData.CityData.Name = item.CityName;
            addressData.CityData.StateData = new StateData();
            addressData.CityData.StateData.Id = item.IdState;
            addressData.CityData.StateData.Name = item.StateName;
            addressData.CityData.StateData.CountryData = new CountryData();
            addressData.CityData.StateData.CountryData.Id = item.IdCountry;
            addressData.CityData.StateData.CountryData.Name = item.CountryName;

            var info = addressService.Update(addressData);
            if (info == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        /// <summary>
        /// Responds to URL: DELETE /userinfo/api/v1/address/{id}.
        /// Removes ID from storage.
        /// </summary>
        /// <returns>Not found if ID is not in storage.</returns>
        /// <param name="id">Identifier.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var info = addressService.Remove(id);
            if (info == null)
            {
                return NotFound();
            }
            return new NoContentResult();
        }
    }
}
