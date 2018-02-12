/*----------------------------------------------------------------------------*/
/* Source File:   MEMORYADDRESSSERVICE.CS                                     */
/* Description:   Service implementation to manage AddressData information.   */
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
    /// Service implementation to manage AddressData information.
    /// </summary>
    public class MemoryAddressService : IAddressService
    {
        private List<AddressData> addresses;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CSoftZ.User.Info.Api.Services.MemoryAddressService"/> class.
        /// </summary>
        public MemoryAddressService()
        {
            this.addresses = new List<AddressData>();
            this.addresses.Add(new AddressData() { Id = 1, Name = "Address 1", CityData = new CityData() { Id = 1, Name = GlobalConstants.CITY_COLOMBIA_ANTIOQUIA_MEDELLIN, StateData = new StateData() { Id = 1, Name = GlobalConstants.STATE_COLOMBIA_ANTIOQUIA, CountryData = new CountryData() { Id = 1, Name = GlobalConstants.COUNTRY_COLOMBIA } } } });
            this.addresses.Add(new AddressData() { Id = 2, Name = "Address 2", CityData = new CityData() { Id = 3, Name = GlobalConstants.CITY_UNITED_STATES_FLORIDA_MIAMI, StateData = new StateData() { Id = 4, Name = GlobalConstants.STATE_UNITED_STATES_FLORIDA, CountryData = new CountryData() { Id = 2, Name = GlobalConstants.COUNTRY_UNITED_STATES } } } });
            this.addresses.Add(new AddressData() { Id = 3, Name = "Address 3", CityData = new CityData() { Id = 5, Name = GlobalConstants.CITY_PERU_MADRE_DE_DIOS_MANU, StateData = new StateData() { Id = 6, Name = GlobalConstants.STATE_PERU_MADRE_DE_DIOS, CountryData = new CountryData() { Id = 3, Name = GlobalConstants.COUNTRY_PERU } } } });
        }

        /// <summary>
        /// Retrieves all records for Addreses.
        /// </summary>
        /// <returns>List of Addresses</returns>
        public List<AddressData> GetAll()
        {
            return addresses;
        }

        /// <summary>
        /// Tries to locate a record by the given Id in storage.
        /// </summary>
        /// <returns>Null if not found.</returns>
        /// <param name="id">Identifier to look for.</param>
        public AddressData GetById(long id)
        {
            return this.addresses.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Adds a new record to the storage.
        /// </summary>
        /// <returns>The newly created record.</returns>
        /// <param name="item">Information to use</param>
        public AddressData Create(AddressData item)
        {
            var numItems = this.addresses.Count;
            var newItem = new AddressData() { Id = numItems + 1, Name = item.Name };
            this.addresses.Add(newItem);
            return newItem;
        }

        /// <summary>
        /// Tries to update the information for a given record.
        /// </summary>
        /// <returns>NULL if record not found or the modified record.</returns>
        /// <param name="item">Information to use</param>
        public AddressData Update(AddressData item)
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
        public AddressData Remove(long id)
        {
            var info = this.GetById(id);
            if (info != null)
            {
                this.addresses.Remove(info);
            }
            return info;
        }
    }
}
