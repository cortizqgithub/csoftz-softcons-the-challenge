/*----------------------------------------------------------------------------*/
/* Source File:   CITYCONTROLLER.CS                                           */
/* Description:   MVC Controller to manage CityData information.              */
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
    /// MVC Controller to manage CityData information.
    /// </summary>
    [Route("userinfo/api/v1/[controller]")]
    public class CityController : Controller
    {
        private readonly ICityService cityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CSoftZ.User.Info.Api.Controllers.CityController"/> class.
        /// </summary>
        /// <param name="cityService">City service.</param>
        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        /// <summary>
        /// Responds to the URL: GET /userinfo/api/v1/city
        /// Retrieves all records.
        /// </summary>
        /// <returns>A list of all cities</returns>
        [HttpGet]
        public List<CityData> GetAll()
        {
            return cityService.GetAll();
        }

        /// <summary>
        /// Responds to the URL: GET /userinfo/api/v1/city/all/country/{idCountry}/state/{idState}
        /// Gets all cities that belong to a State/Country.
        /// </summary>
        /// <returns>List of Cities</returns>
        /// <param name="idCountry">Country Identifier.</param>
        /// <param name="idState">State Identifier..</param>
        [HttpGet("all/country/{idCountry}/state/{idState}")]
        public List<CityData> GetAllByCountryState(long idCountry, long idState)
        {
            return cityService.GetAllByCountryState(idCountry, idState);
        }

        /// <summary>
        /// Responds to the URL: GET /userinfo/api/v1/city/{id}.
        /// Where {id} is a placeholder for the id to look for.
        /// </summary>
        /// <returns>A HTTP Not Found or object found</returns>
        /// <param name="id">Identifier to look up.</param>
        [HttpGet("{id}", Name = "GetCityData")]
        public IActionResult GetById(long id)
        {
            var item = cityService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        /// <summary>
        /// Responds to the URL: POST /userinfo/api/v1/city
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

            CityData cityData = new CityData();
            cityData.Id = item.IdCity;
            cityData.Name = item.CityName;
            cityData.StateData = new StateData();
            cityData.StateData.Id = item.IdState;
            cityData.StateData.Name = item.StateName;
            cityData.StateData.CountryData = new CountryData();
            cityData.StateData.CountryData.Id = item.IdCountry;
            cityData.StateData.CountryData.Name = item.CountryName;
                
            var info = cityService.Create(cityData);
            return CreatedAtRoute("GetCityData", new { id = info.Id }, info);
        }

        /// <summary>
        /// Responds to URL: PUT /userinfo/api/v1/city/{id}.
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
            if (item == null || item.IdCity != id)
            {
                return BadRequest();
            }

            CityData cityData = new CityData();
            cityData.Id = item.IdCity;
            cityData.Name = item.CityName;
            cityData.StateData = new StateData();
            cityData.StateData.Id = item.IdState;
            cityData.StateData.Name = item.StateName;
            cityData.StateData.CountryData = new CountryData();
            cityData.StateData.CountryData.Id = item.IdCountry;
            cityData.StateData.CountryData.Name = item.CountryName;

            var info = cityService.Update(cityData);
            if (info == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        /// <summary>
        /// Responds to URL: DELETE /userinfo/api/v1/city/{id}.
        /// Removes ID from storage.
        /// </summary>
        /// <returns>Not found if ID is not in storage.</returns>
        /// <param name="id">Identifier.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var info = cityService.Remove(id);
            if (info == null)
            {
                return NotFound();
            }
            return new NoContentResult();
        }
    }
}
