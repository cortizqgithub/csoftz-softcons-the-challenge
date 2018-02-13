/*----------------------------------------------------------------------------*/
/* Source File:   STATECONTROLLER.CS                                          */
/* Description:   MVC Controller to manage StateData information.             */
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
using Microsoft.AspNetCore.Mvc;
using CSoftZ.User.Info.Api.Domain;
using CSoftZ.User.Info.Api.Services.Interfaces;

namespace CSoftZ.User.Info.Api.Controllers
{
    /// <summary>
    /// MVC Controller to manage StateData information.
    /// </summary>
    [Route("userinfo/api/v1/[controller]")]
    public class StateController : Controller
    {
        private readonly IStateService stateService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CSoftZ.User.Info.Api.Controllers.StateController"/> class.
        /// </summary>
        /// <param name="stateService">State service.</param>
        public StateController(IStateService stateService)
        {
            this.stateService = stateService;
        }

        /// <summary>
        /// Responds to the URL: GET /userinfo/api/v1/state
        /// Retrieves all records.
        /// </summary>
        /// <returns>A list of all states</returns>
        [HttpGet]
        public List<StateData> GetAll()
        {
            return stateService.GetAll();
        }

        /// <summary>
        /// Responds to the URL: GET /userinfo/api/v1/state/all/country/{idCountry}
        /// Gets all States that belongs to given country Id.
        /// </summary>
        /// <returns>List of States for Country</returns>
        /// <param name="idCountry">Country Identifier.</param>
        [HttpGet("all/country/{idCountry}")]
        public List<StateData> GetAllByCountry(long idCountry)
        {
            return stateService.GetAllByCountry(idCountry);
        }

        /// <summary>
        /// Responds to the URL: GET /userinfo/api/v1/state/{id}.
        /// Where {id} is a placeholder for the id to look for.
        /// </summary>
        /// <returns>A HTTP Not Found or object found</returns>
        /// <param name="id">Identifier to look up.</param>
        [HttpGet("{id}", Name = "GetStateData")]
        public IActionResult GetById(long id)
        {
            var item = stateService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        /// <summary>
        /// Responds to the URL: POST /userinfo/api/v1/state
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
            StateData stateData = new StateData();
            stateData.Name = item.StateName;
            stateData.CountryData = new CountryData();
            stateData.CountryData.Id = item.IdCountry;
            stateData.CountryData.Name = item.CountryName;

            var info = stateService.Create(stateData);
            return CreatedAtRoute("GetStateData", new { id = info.Id }, info);
        }

        /// <summary>
        /// Responds to URL: PUT /userinfo/api/v1/state/{id}.
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
            if (item == null || item.IdState != id)
            {
                return BadRequest();
            }

            StateData stateData = new StateData();
            stateData.Id = item.IdState;
            stateData.Name = item.StateName;
            stateData.CountryData = new CountryData();
            stateData.CountryData.Id = item.IdCountry;
            stateData.CountryData.Name = item.CountryName;
            var info = stateService.Update(stateData);
            if (info == null)
            {
                return NotFound();
            }
            return new ObjectResult(info);
        }

        /// <summary>
        /// Responds to URL: DELETE /userinfo/api/v1/state/{id}.
        /// Removes ID from storage.
        /// </summary>
        /// <returns>Not found if ID is not in storage.</returns>
        /// <param name="id">Identifier.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var info = stateService.Remove(id);
            if (info == null)
            {
                return NotFound();
            }
            return new NoContentResult();
        }
    }
}
