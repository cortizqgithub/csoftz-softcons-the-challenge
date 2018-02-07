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

using System.Linq;
using System.Collections.Generic;
using CSoftZ.User.Info.Api.Domain;
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
            this.addresses.Add(new AddressData() { Id = 1, Name = "Colombia" });
            this.addresses.Add(new AddressData() { Id = 2, Name = "United Addresss" });
            this.addresses.Add(new AddressData() { Id = 3, Name = "Peru" });
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
        public AddressData Remove(long id)
        {
            var info = this.GetById(id);
            if (info != null) {
                this.addresses.Remove(info);
            }
            return info;
        }
    }
}
