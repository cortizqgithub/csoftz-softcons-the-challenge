/*----------------------------------------------------------------------------*/
/* Source File:   MEMORYCITYSERVICE.CS                                        */
/* Description:   Service implementation to manage CityData information.      */
/* Author:        Carlos Adolfo Ortiz Quirós (COQ)                            */
/* Date:          Feb.07/2018                                                 */
/* Last Modified: Feb.07/2018                                                 */
/* Version:       1.1                                                         */
/* Copyright (c), 2018 CSoftZ.                                                */
/*----------------------------------------------------------------------------*/
/*-----------------------------------------------------------------------------
 History
 Feb.07/2018 COQ  File created.
 -----------------------------------------------------------------------------*/

using System.Collections.Generic;
using System.Linq;
using CSoftZ.User.Info.Api.Domain;
using CSoftZ.User.Info.Api.Helper.Consts;
using CSoftZ.User.Info.Api.Services.Interfaces;

namespace CSoftZ.User.Info.Api.Services
{
    /// <summary>
    /// Service implementation to manage CityData information.
    /// </summary>
    public class MemoryCityService : ICityService
    {
        private List<CityData> cities;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CSoftZ.User.Info.Api.Services.MemoryCityService"/> class.
        /// </summary>
        public MemoryCityService()
        {
            this.cities = new List<CityData>();
            this.cities.Add(new CityData() { Id = 1, Name = GlobalConstants.CITY_COLOMBIA_ANTIOQUIA_MEDELLIN, StateData = new StateData() { Id = 1, Name = GlobalConstants.STATE_COLOMBIA_ANTIOQUIA, CountryData = new CountryData() { Id = 1, Name = GlobalConstants.COUNTRY_COLOMBIA } } });
            this.cities.Add(new CityData() { Id = 2, Name = GlobalConstants.CITY_COLOMBIA_ANTIOQUIA_CALDAS, StateData = new StateData() { Id = 1, Name = GlobalConstants.STATE_COLOMBIA_ANTIOQUIA, CountryData = new CountryData() { Id = 1, Name = GlobalConstants.COUNTRY_COLOMBIA } } });
            this.cities.Add(new CityData() { Id = 3, Name = GlobalConstants.CITY_UNITED_STATES_FLORIDA_MIAMI, StateData = new StateData() { Id = 4, Name = GlobalConstants.STATE_UNITED_STATES_FLORIDA, CountryData = new CountryData() { Id = 2, Name = GlobalConstants.COUNTRY_UNITED_STATES } } });
            this.cities.Add(new CityData() { Id = 4, Name = GlobalConstants.CITY_UNITED_STATES_NEW_YORK_NEW_YORK, StateData = new StateData() { Id = 5, Name = GlobalConstants.STATE_UNITED_STATES_NEW_YORK, CountryData = new CountryData() { Id = 2, Name = GlobalConstants.COUNTRY_UNITED_STATES } } });
            this.cities.Add(new CityData() { Id = 5, Name = GlobalConstants.CITY_PERU_MADRE_DE_DIOS_MANU, StateData = new StateData() { Id = 6, Name = GlobalConstants.STATE_PERU_MADRE_DE_DIOS, CountryData = new CountryData() { Id = 3, Name = GlobalConstants.COUNTRY_PERU } } });
            this.cities.Add(new CityData() { Id = 6, Name = GlobalConstants.CITY_PERU_LIMA_LIMA, StateData = new StateData() { Id = 7, Name = GlobalConstants.STATE_PERU_LIMA, CountryData = new CountryData() { Id = 3, Name = GlobalConstants.COUNTRY_PERU } } });
        }

        /// <summary>
        /// Retrieves all records for Cities.
        /// </summary>
        /// <returns>List of Cities</returns>
        public List<CityData> GetAll()
        {
            return cities;
        }

        /// <summary>
        /// Tries to locate a record by the given Id in storage.
        /// </summary>
        /// <returns>Null if not found.</returns>
        /// <param name="id">Identifier to look for.</param>
        public CityData GetById(long id)
        {
            return this.cities.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Adds a new record to the storage.
        /// </summary>
        /// <returns>The newly created record.</returns>
        /// <param name="item">Information to use</param>
        public CityData Create(CityData item)
        {
            var numItems = this.cities.Count;
            var newItem = new CityData() { Id = numItems + 1, Name = item.Name };
            this.cities.Add(newItem);
            return newItem;
        }

        /// <summary>
        /// Tries to update the information for a given record.
        /// </summary>
        /// <returns>NULL if record not found or the modified record.</returns>
        /// <param name="item">Information to use</param>
        public CityData Update(CityData item)
        {
            var info = this.GetById(item.Id);
            if (info != null)
            {
                info.Name = item.Name;
            }
            return info;
        }

        /// <summary>
        /// Tries to remove a record for the given Id from storage.
        /// </summary>
        /// <returns>The remove.</returns>
        /// <param name="id">Identifier to look for.</param>
        public CityData Remove(long id)
        {
            var info = this.GetById(id);
            if (info != null)
            {
                this.cities.Remove(info);
            }
            return info;
        }
    }
}
