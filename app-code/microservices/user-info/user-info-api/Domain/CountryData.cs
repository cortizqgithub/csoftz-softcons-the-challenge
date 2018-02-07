/*----------------------------------------------------------------------------*/
/* Source File:   COUNTRYDATA.CS                                              */
/* Description:   Domain class to handle CountryData information.             */
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
    /// Domain class to handle CountryData information.
    /// </summary>
    public class CountryData
    {
        public long Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Default Constructor.
        /// Initializes a new instance of the <see cref="T:CSoftZ.User.Info.Api.Domain.CountryData"/> class.
        /// </summary>
        public CountryData()
        {
            this.Id = 0;
            this.Name = "";
        }
    }
}
