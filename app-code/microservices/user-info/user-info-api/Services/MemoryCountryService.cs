/*----------------------------------------------------------------------------*/
/* Source File:   MEMORYCOUNTRYSERVICE.CS                                     */
/* Description:   Service implementation to manage Country information.       */
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

using System.Linq;
using System.Collections.Generic;
using CSoftZ.User.Info.Api.Domain;
using CSoftZ.User.Info.Api.Services.Interfaces;

namespace CSoftZ.User.Info.Api.Services
{
    /// <summary>
    /// Service implementation to manage Country information.
    /// </summary>
    public class MemoryCountryService : ICountryService
    {
        private List<Country> countries;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:User.Info.Api.Services.MemoryCountryService"/> class.
        /// </summary>
        public MemoryCountryService()
        {
            this.countries = new List<Country>();
            this.countries.Add(new Country() { Id = 1, Name = "Colombia" });
            this.countries.Add(new Country() { Id = 2, Name = "United States" });
            this.countries.Add(new Country() { Id = 3, Name = "Peru" });
        }

        /// <summary>
        /// Retrieves all records for Countries.
        /// </summary>
        /// <returns>List of Countries</returns>
        public List<Country> GetAll()
        {
            return countries;
        }

        /// <summary>
        /// Tries to locate a record by the given Id in storage.
        /// </summary>
        /// <returns>Null if not found.</returns>
        /// <param name="id">Identifier to look for.</param>
        public Country GetById(long id)
        {
            return this.countries.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Adds a new record to the storage.
        /// </summary>
        /// <returns>The newly created record.</returns>
        /// <param name="item">Information to use</param>
        public Country Create(Country item)
        {
            var numItems = this.countries.Count;
            var newItem = new Country() { Id = numItems + 1, Name = item.Name };
            this.countries.Add(newItem);
            return newItem;
        }

        /// <summary>
        /// Tries to update the information for a given record.
        /// </summary>
        /// <returns>NULL if record not found or the modified record.</returns>
        /// <param name="item">Information to use</param>
        public Country Update(Country item)
        {
            var info = this.GetById(item.Id);
            if (info != null){
                info.Name = item.Name;
            }
            return info;
        }

        /// <summary>
        /// Tries to remove a record for the given Id from storage.
        /// </summary>
        /// <returns>The remove.</returns>
        /// <param name="id">Identifier to look for.</param>
        public Country Remove(long id)
        {
            var info = this.GetById(id);
            if (info != null) {
                this.countries.Remove(info);
            }
            return info;
        }
    }
}
