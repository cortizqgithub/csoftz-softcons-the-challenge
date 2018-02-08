/*----------------------------------------------------------------------------*/
/* Source File:   STATECONTROLLER.CS                                          */
/* Description:   Controller to administer State assets.                      */
/* Author:        Carlos Adolfo Ortiz Quirós (COQ)                            */
/* Date:          Feb.08/2018                                                 */
/* Last Modified: Feb.08/2018                                                 */
/* Version:       1.1                                                         */
/* Copyright (c), 2018 CSoftZ.                                                */
/*----------------------------------------------------------------------------*/
/*-----------------------------------------------------------------------------
 History
 Feb.08/2018 COQ  File created.
 -----------------------------------------------------------------------------*/

using Microsoft.AspNetCore.Mvc;

namespace userinfowebmvc.Controllers
{
    /// <summary>
    /// Controller to administer State assets.
    /// </summary>
    public class StateController : Controller
    {
        /// <summary>
        /// Shows the Index Page for State Assets.
        /// </summary>
        /// <returns>The Index page for State</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
