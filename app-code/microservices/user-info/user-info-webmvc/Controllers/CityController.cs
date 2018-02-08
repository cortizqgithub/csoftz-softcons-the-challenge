/*----------------------------------------------------------------------------*/
/* Source File:   CITYCONTROLLER.CS                                           */
/* Description:   Controller to administer City assets.                       */
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
    /// Controller to administer City assets.
    /// </summary>
    public class CityController : Controller
    {
        /// <summary>
        /// Shows the Index Page for City Assets.
        /// </summary>
        /// <returns>The Index page for City</returns>   
        public IActionResult Index()
        {
            return View();
        }
    }
}
