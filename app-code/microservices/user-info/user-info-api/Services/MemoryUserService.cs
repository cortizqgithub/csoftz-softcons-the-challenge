/*----------------------------------------------------------------------------*/
/* Source File:   MEMORYUSERSERVICE.CS                                        */
/* Description:   Service implementation to manage UserData information.      */
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
    /// Service implementation to manage UserData information.
    /// </summary>
    public class MemoryUserService : IUserService
    {
        private List<UserData> users;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CSoftZ.User.Info.Api.Services.MemoryUserService"/> class.
        /// </summary>
        public MemoryUserService()
        {
            this.users = new List<UserData>();

            var userData = new UserData() { Id = 1, Name = "Charlie Brown" };
            userData.Addresses.Add(new AddressData() { Id = 1, Name = "Address 1", CityData = new CityData() { Id = 1, Name = GlobalConstants.CITY_COLOMBIA_ANTIOQUIA_MEDELLIN, StateData = new StateData() { Id = 1, Name = GlobalConstants.STATE_COLOMBIA_ANTIOQUIA, CountryData = new CountryData() { Id = 1, Name = GlobalConstants.COUNTRY_COLOMBIA } } } });
            userData.Addresses.Add(new AddressData() { Id = 2, Name = "Address 2", CityData = new CityData() { Id = 3, Name = GlobalConstants.CITY_UNITED_STATES_FLORIDA, StateData = new StateData() { Id = 4, Name = GlobalConstants.STATE_UNITED_STATES_FLORIDA, CountryData = new CountryData() { Id = 2, Name = GlobalConstants.COUNTRY_UNITED_STATES } } } });
            this.users.Add(userData);

        }

        /// <summary>
        /// Retrieves all records for Users.
        /// </summary>
        /// <returns>List of Users</returns>
        public List<UserData> GetAll()
        {
            return users;
        }

        /// <summary>
        /// Tries to locate a record by the given Id in storage.
        /// </summary>
        /// <returns>Null if not found.</returns>
        /// <param name="id">Identifier to look for.</param>
        public UserData GetById(long id)
        {
            return this.users.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Adds a new record to the storage.
        /// </summary>
        /// <returns>The newly created record.</returns>
        /// <param name="item">Information to use</param>
        public UserData Create(UserData item)
        {
            var numItems = this.users.Count;
            var newItem = new UserData() { Id = numItems + 1, Name = item.Name };
            this.users.Add(newItem);
            return newItem;
        }

        /// <summary>
        /// Tries to update the information for a given record.
        /// </summary>
        /// <returns>NULL if record not found or the modified record.</returns>
        /// <param name="item">Information to use</param>
        public UserData Update(UserData item)
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
        public UserData Remove(long id)
        {
            var info = this.GetById(id);
            if (info != null) {
                this.users.Remove(info);
            }
            return info;
        }
    }
}
