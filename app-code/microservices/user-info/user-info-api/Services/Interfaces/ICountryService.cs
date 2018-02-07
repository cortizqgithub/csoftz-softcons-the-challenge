﻿/*----------------------------------------------------------------------------*/
/* Source File:   ICOUNTRYSERVICE.CS                                          */
/* Description:   Service to manage Country information.                      */
/* Author:        Carlos Adolfo Ortiz Quirós (COQ)                            */
/* Date:          Feb.06/2018                                                 */
/* Last Modified: Feb.06/2018                                                 */
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
    /// Service to manage Country information.
    /// </summary>
    public interface ICountryService
    {
        /// <summary>
        /// Retrieves all records for Countries.
        /// </summary>
        /// <returns>List of Countries</returns>
        List<Country> GetAll();

        /// <summary>
        /// Tries to locate a record by the given Id in storage.
        /// </summary>
        /// <returns>Null if not found.</returns>
        /// <param name="id">Identifier to look for.</param>
        Country GetById(long id);

        /// <summary>
        /// Adds a new record to the storage.
        /// </summary>
        /// <returns>The newly created record.</returns>
        /// <param name="item">Information to use</param>
        Country Create(Country item);

        /// <summary>
        /// Tries to update the information for a given record.
        /// </summary>
        /// <returns>NULL if record not found or the modified record.</returns>
        /// <param name="item">Information to use</param>
        Country Update(Country item);

        /// <summary>
        /// Tries to remove a record for the given Id from storage.
        /// </summary>
        /// <returns>The remove.</returns>
        /// <param name="id">Identifier to look for.</param>
        Country Remove(long id);
    }
}