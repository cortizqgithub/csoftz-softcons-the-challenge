/*----------------------------------------------------------------------------*/
/* Source File:   GLOBALCONSTANTS.VB                                          */
/* Description:   Global application Constants                                */
/* Author:        Carlos Adolfo Ortiz Quirós (COQ)                            */
/* Date:          Feb.07/2018                                                 */
/* Last Modified: Feb.07/2018                                                 */
/* Version:       1.1                                                         */
/* Copyright (c), 2018 CSoftZ                                                 */
/*----------------------------------------------------------------------------*/

/*-----------------------------------------------------------------------------
 History
 Feb.07/2018 COQ  File created.
 -----------------------------------------------------------------------------*/

namespace CSoftZ.User.Info.Api.Helper.Consts
{
    /// <summary>
    /// Global application Constants. Used as a static class access only. This way it
    /// is assured that a change in the constant value is modified in one place.
    /// </summary>
    public class GlobalConstants
    {
        // Global GlobalConstants
        public const string COUNTRY_COLOMBIA = "Colombia";
        public const string COUNTRY_UNITED_STATES = "United States";
        public const string COUNTRY_PERU = "Peru";

        public const string STATE_COLOMBIA_ANTIOQUIA = "Antioquia";
        public const string STATE_COLOMBIA_CALDAS = "Caldas";
        public const string STATE_COLOMBIA_ATLANTICO = "Atlantico";

        public const string STATE_UNITED_STATES_FLORIDA = "Florida";
        public const string STATE_UNITED_STATES_NEW_YORK = "New York";

        public const string STATE_PERU_MADRE_DE_DIOS = "Madre de Dios";
        public const string STATE_PERU_LIMA = "Lima";

        public const string CITY_COLOMBIA_ANTIOQUIA_MEDELLIN = "Medellin";
        public const string CITY_COLOMBIA_ANTIOQUIA_CALDAS = "Caldas";

        public const string CITY_UNITED_STATES_FLORIDA = "Miami";
        public const string CITY_UNITED_STATES_NEW_YORK_NEW_YORK = "New York";

        public const string CITY_PERU_MADRE_DE_DIOS_MANU = "Manu";
        public const string CITY_PERU_LIMA_LIMA = "Lima";
    }
}
