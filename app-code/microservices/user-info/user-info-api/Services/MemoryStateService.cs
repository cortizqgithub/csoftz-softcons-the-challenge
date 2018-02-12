/*----------------------------------------------------------------------------*/
/* Source File:   MEMORYSTATESERVICE.CS                                       */
/* Description:   Service implementation to manage StateData information.     */
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
using System.Linq;
using CSoftZ.User.Info.Api.Domain;
using CSoftZ.User.Info.Api.Helper.Consts;
using CSoftZ.User.Info.Api.Services.Interfaces;

namespace CSoftZ.User.Info.Api.Services
{
    /// <summary>
    /// Service implementation to manage StateData information.
    /// </summary>
    public class MemoryStateService : IStateService
    {
        private List<StateData> states;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CSoftZ.User.Info.Api.Services.MemoryStateService"/> class.
        /// </summary>
        public MemoryStateService()
        {
            this.states = new List<StateData>();
            this.states.Add(new StateData() { Id = 1, Name = GlobalConstants.STATE_COLOMBIA_ANTIOQUIA, CountryData = new CountryData() { Id = 1, Name = GlobalConstants.COUNTRY_COLOMBIA } });
            this.states.Add(new StateData() { Id = 2, Name = GlobalConstants.STATE_COLOMBIA_CALDAS, CountryData = new CountryData() { Id = 1, Name = GlobalConstants.COUNTRY_COLOMBIA } });
            this.states.Add(new StateData() { Id = 3, Name = GlobalConstants.STATE_COLOMBIA_ATLANTICO, CountryData = new CountryData() { Id = 1, Name = GlobalConstants.COUNTRY_COLOMBIA } });
            this.states.Add(new StateData() { Id = 4, Name = GlobalConstants.STATE_UNITED_STATES_FLORIDA, CountryData = new CountryData() { Id = 2, Name = GlobalConstants.COUNTRY_UNITED_STATES } });
            this.states.Add(new StateData() { Id = 5, Name = GlobalConstants.STATE_UNITED_STATES_NEW_YORK, CountryData = new CountryData() { Id = 2, Name = GlobalConstants.COUNTRY_UNITED_STATES } });
            this.states.Add(new StateData() { Id = 6, Name = GlobalConstants.STATE_PERU_MADRE_DE_DIOS, CountryData = new CountryData() { Id = 3, Name = GlobalConstants.COUNTRY_PERU } });
            this.states.Add(new StateData() { Id = 7, Name = GlobalConstants.STATE_PERU_LIMA, CountryData = new CountryData() { Id = 3, Name = GlobalConstants.COUNTRY_PERU } });
        }

        /// <summary>
        /// Retrieves all records for States.
        /// </summary>
        /// <returns>List of States</returns>
        public List<StateData> GetAll()
        {
            return states;
        }

        /// <summary>
        /// Gets all States that belongs to given country Id.
        /// </summary>
        /// <returns>List of States for Country</returns>
        /// <param name="idCountry">Country Identifier</param>
        public List<StateData> GetAllByCountry(long idCountry)
        {
            return (from state in states
                    where state.CountryData.Id == idCountry
                    select state).ToList();
        }

        /// <summary>
        /// Tries to locate a record by the given Id in storage.
        /// </summary>
        /// <returns>Null if not found.</returns>
        /// <param name="id">Identifier to look for.</param>
        public StateData GetById(long id)
        {
            return this.states.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Adds a new record to the storage.
        /// </summary>
        /// <returns>The newly created record.</returns>
        /// <param name="item">Information to use</param>
        public StateData Create(StateData item)
        {
            var numItems = this.states.Count;
            var newItem = new StateData() { Id = numItems + 1, Name = item.Name };
            this.states.Add(newItem);
            return newItem;
        }

        /// <summary>
        /// Tries to update the information for a given record.
        /// </summary>
        /// <returns>NULL if record not found or the modified record.</returns>
        /// <param name="item">Information to use</param>
        public StateData Update(StateData item)
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
        public StateData Remove(long id)
        {
            var info = this.GetById(id);
            if (info != null)
            {
                this.states.Remove(info);
            }
            return info;
        }
    }
}
