/*----------------------------------------------------------------------------*/
/* Source File:   ADDRESSCONTROLLER.CS                                        */
/* Description:   Controller to administer Address assets.                    */
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
    /// Controller to administer Address assets.
    /// </summary>
    public class AddressController : Controller
    {
        /// <summary>
        /// Shows the Index Page for Address Assets.
        /// </summary>
        /// <returns>The Index page for Address</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
