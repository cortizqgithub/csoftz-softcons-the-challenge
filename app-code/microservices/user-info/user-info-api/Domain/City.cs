/*----------------------------------------------------------------------------*/
/* Source File:   CITY.CS                                                     */
/* Description:   Domain class to handle City information.                    */
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
    /// Domain class to handle City information.
    /// </summary>
    public class City
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public State State { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:User.Info.Api.Domain.City"/> class.
        /// </summary>
        public City()
        {
            this.Id = 0;
            this.Name = "";
            this.State = new State();
        }
    }
}
