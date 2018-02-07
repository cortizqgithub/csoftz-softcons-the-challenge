/*----------------------------------------------------------------------------*/
/* Source File:   STATEDATA.CS                                                */
/* Description:   Domain class to handle StateData information.               */
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
    /// Domain class to handle StateData information.
    /// </summary>
    public class StateData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CountryData CountryData { get; set; }

        /// <summary>
        /// Default Constructor.
        /// Initializes a new instance of the <see cref="T:CSoftZ.User.Info.Api.Domain.StateData"/> class.
        /// </summary>
        public StateData()
        {
            this.Id = 0;
            this.Name = "";
            this.CountryData = new CountryData();
        }
    }
}
