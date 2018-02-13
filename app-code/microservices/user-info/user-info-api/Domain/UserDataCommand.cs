/*----------------------------------------------------------------------------*/
/* Source File:   USERDATACOMMAND.CS                                          */
/* Description:   Command class to insert/update operations.                  */
/* Author:        Carlos Adolfo Ortiz Quirós (COQ)                            */
/* Date:          Feb.12/2018                                                 */
/* Last Modified: Feb.12/2018                                                 */
/* Version:       1.1                                                         */
/* Copyright (c), 2018 CSoftZ.                                                */
/*----------------------------------------------------------------------------*/
/*-----------------------------------------------------------------------------
 History
 Feb.12/2018 COQ  File created.
 -----------------------------------------------------------------------------*/

namespace CSoftZ.User.Info.Api.Domain
{
    /// <summary>
    /// Command class to insert/update operations.
    /// </summary>
    public class UserDataCommand
    {
        public long IdCountry { get; set; }
        public string CountryName { get; set; }
        public long IdState { get; set; }
        public string StateName { get; set; }
        public long IdCity { get; set; }
        public string CityName { get; set; }
        public long IdAddress { get; set; }
        public string AddressName { get; set; }
        public long IdUser { get; set; }
        public string UserName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CSoftZ.User.Info.Api.Domain.UserDataCommand"/> class.
        /// </summary>
        public UserDataCommand()
        {
            this.IdCountry = 0;
            this.CountryName = "";
            this.IdState = 0;
            this.StateName = "";
            this.IdCity = 0;
            this.CityName = "";
            this.IdAddress = 0;
            this.AddressName = "";
            this.IdUser = 0;
            this.UserName = "";
        }
    }
}
