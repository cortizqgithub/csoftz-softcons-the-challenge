/*----------------------------------------------------------------------------*/
/* Source File:   ISTATESERVICE.CS                                            */
/* Description:   Service to manage StateData information.                    */
/* Author:        Carlos Adolfo Ortiz Quirós (COQ)                            */
/* Date:          Feb.06/2018                                                 */
/* Last Modified: Feb.12/2018                                                 */
/* Version:       1.1                                                         */
/* Copyright (c), 2018 CSoftZ.                                                */
/*----------------------------------------------------------------------------*/
/*-----------------------------------------------------------------------------
 History
 Feb.06/2018 COQ  File created.
 -----------------------------------------------------------------------------*/

using System.Collections.Generic;
using CSoftZ.User.Info.Api.Domain;

namespace CSoftZ.User.Info.Api.Services.Interfaces
{
    /// <summary>
    /// Service to manage StateData information.
    /// </summary>
    public interface IStateService
    {
        /// <summary>
        /// Retrieves all records for Countries.
        /// </summary>
        /// <returns>List of States</returns>
        List<StateData> GetAll();

        /// <summary>
        /// Gets all States that belongs to given country Id.
        /// </summary>
        /// <returns>List of States for Country</returns>
        /// <param name="idCountry">Country Identifier</param>
        List<StateData> GetAllByCountry(long idCountry);

        /// <summary>
        /// Tries to locate a record by the given Id in storage.
        /// </summary>
        /// <returns>Null if not found.</returns>
        /// <param name="id">Identifier to look for.</param>
        StateData GetById(long id);

        /// <summary>
        /// Adds a new record to the storage.
        /// </summary>
        /// <returns>The newly created record.</returns>
        /// <param name="item">Information to use</param>
        StateData Create(StateData item);

        /// <summary>
        /// Tries to update the information for a given record.
        /// </summary>
        /// <returns>NULL if record not found or the modified record.</returns>
        /// <param name="item">Information to use</param>
        StateData Update(StateData item);

        /// <summary>
        /// Tries to remove a record for the given Id from storage.
        /// </summary>
        /// <returns>The remove.</returns>
        /// <param name="id">Identifier to look for.</param>
        StateData Remove(long id);
    }
}