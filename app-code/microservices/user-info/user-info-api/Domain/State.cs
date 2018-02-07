/*----------------------------------------------------------------------------*/
/* Source File:   STATE.CS                                                    */
/* Description:   Domain class to handle State information.                   */
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
    /// Domain class to handle State information.
    /// </summary>
    public class State
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }

        /// <summary>
        /// Default Constructor.
        /// Initializes a new instance of the <see cref="T:CSoftZ.User.Info.Api.Domain.State"/> class.
        /// </summary>
        public State()
        {
            this.Id = 0;
            this.Name = "";
            this.Country = new Country();
        }
    }
}
