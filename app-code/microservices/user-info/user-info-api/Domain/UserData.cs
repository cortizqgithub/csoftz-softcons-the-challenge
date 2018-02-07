/*----------------------------------------------------------------------------*/
/* Source File:   USERDATA.CS                                                 */
/* Description:   Domain class to handle UserData information.                */
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

namespace CSoftZ.User.Info.Api.Domain
{
    /// <summary>
    /// Domain class to handle UserData information.
    /// </summary>
    public class UserData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<AddressData> Addresses { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CSoftZ.User.Info.Api.Domain.UserData"/> class.
        /// </summary>
        public UserData()
        {
            this.Id = 0;
            this.Name = "";
            this.Addresses = new List<AddressData>();
        }
    }
}
