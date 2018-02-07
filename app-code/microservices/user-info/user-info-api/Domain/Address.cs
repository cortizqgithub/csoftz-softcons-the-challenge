/*----------------------------------------------------------------------------*/
/* Source File:   ADDRESS.CS                                                  */
/* Description:   Domain class to handle Address information.                 */
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
    /// Domain class to handle Address information.
    /// </summary>
    public class Address
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:User.Info.Api.Domain.Address"/> class.
        /// </summary>
        public Address()
        {
            this.Id = 0;
            this.Name = "";
            this.City = new City();
        }
    }
}
