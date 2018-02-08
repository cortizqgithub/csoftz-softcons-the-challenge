/*----------------------------------------------------------------------------*/
/* Source File:   HOMECONTROLLER.CS                                           */
/* Description:   Controller for HOME assets.                                 */
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

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using user_info_webmvc.Models;

namespace user_info_webmvc.Controllers
{
    /// <summary>
    /// Controller for HOME assets.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Shows the HOME page.
        /// </summary>
        /// <returns>The view for HOME page</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Shows the ABOUT page.
        /// </summary>
        /// <returns>The view for ABOUT page</returns>
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Shows the CONTACT page.
        /// </summary>
        /// <returns>The contact view page.</returns>
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Shows the ERROR page.
        /// </summary>
        /// <returns>The error view page.</returns>
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
