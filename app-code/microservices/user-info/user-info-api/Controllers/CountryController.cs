/*----------------------------------------------------------------------------*/
/* Source File:   COUNTRYCONTROLLER.CS                                        */
/* Description:   MVC Controller to manage CountryData information.               */
/* Author:        Carlos Adolfo Ortiz Quirós (COQ)                            */
/* Date:          Feb.06/2018                                                 */
/* Last Modified: Feb.07/2018                                                 */
/* Version:       1.1                                                         */
/* Copyright (c), 2018 CSoftZ.                                                */
/*----------------------------------------------------------------------------*/
/*-----------------------------------------------------------------------------
 History
 Feb.06/2018 COQ  File created.
 -----------------------------------------------------------------------------*/

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CSoftZ.User.Info.Api.Domain;
using CSoftZ.User.Info.Api.Services.Interfaces;

namespace CSoftZ.User.Info.Api.Controllers
{
    /// <summary>
    /// MVC Controller to manage CountryData information.
    /// </summary>
    [Route("userinfo/api/v1/[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryService countryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:User.Info.Api.Controllers.CountryController"/> class.
        /// </summary>
        /// <param name="countryService">Country service.</param>
        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        /// <summary>
        /// Responds to the URL: GET /userinfo/api/v1/country
        /// Retrieves all records.
        /// </summary>
        /// <returns>A list of all countries</returns>
        [HttpGet]
        public List<CountryData> GetAll()
        {
            return countryService.GetAll();
        }

        /// <summary>
        /// Responds to the URL: GET /userinfo/api/v1/country/{id}.
        /// Where {id} is a placeholder for the id to look for.
        /// </summary>
        /// <returns>A HTTP Not Found or object found</returns>
        /// <param name="id">Identifier to look up.</param>
        [HttpGet("{id}", Name = "GetCountryData")]
        public IActionResult GetById(long id)
        {
            var item = countryService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        /// <summary>
        /// Responds to the URL: POST /userinfo/api/v1/country
        /// Create a record in storage.
        /// </summary>
        /// <returns>The created record and HTTP status created</returns>
        /// <param name="item">Record information to create.</param>
        [HttpPost]
        public IActionResult Create([FromBody] CountryData item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var info = countryService.Create(item);
            return CreatedAtRoute("GetCountryData", new { id = info.Id }, info);
        }

        /// <summary>
        /// Responds to URL: PUT /userinfo/api/v1/country/{id}.
        /// Where {id} is a placeholder for the id to look for.
        /// </summary>
        /// <returns>A bad request if parameters are not corrrect.
        /// A not found record or the updated record.
        /// </returns>
        /// <param name="id">Identifier to update.</param>
        /// <param name="item">Record information to update.</param>
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] CountryData item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var info = countryService.Update(item);
            if (info == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        /// <summary>
        /// Responds to URL: DELETE /userinfo/api/v1/country/{id}.
        /// Removes ID from storage.
        /// </summary>
        /// <returns>Not found if ID is not in storage.</returns>
        /// <param name="id">Identifier.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var info = countryService.Remove(id);
            if (info == null)
            {
                return NotFound();
            }
            return new NoContentResult();
        }
    }
}
