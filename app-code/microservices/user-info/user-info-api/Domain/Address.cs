/*----------------------------------------------------------------------------*/
/* Source File:   ADDRESSDATA.CS                                              */
/* Description:   Domain class to handle AddressData information.             */
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

namespace CSoftZ.User.Info.Api.Domain
{
    /// <summary>
    /// Domain class to handle AddressData information.
    /// </summary>
    public class AddressData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CityData CityData { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CSoftZ.User.Info.Api.Domain.AddressData"/> class.
        /// </summary>
        public AddressData()
        {
            this.Id = 0;
            this.Name = "";
            this.CityData = new CityData();
        }
    }
}
