/*----------------------------------------------------------------------------*/
/* Source File:   USER.CS                                                     */
/* Description:   Domain class to handle User information.                    */
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
    /// Domain class to handle User information.
    /// </summary>
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Address> Addresses { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:User.Info.Api.Domain.User"/> class.
        /// </summary>
        public User()
        {
            this.Id = 0;
            this.Name = "";
            this.Addresses = new List<Address>();
        }
    }
}
