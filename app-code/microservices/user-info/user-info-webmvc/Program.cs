/*----------------------------------------------------------------------------*/
/* Source File:   PROGRAM.CS                                                  */
/* Description:   Program Startup.                                            */
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

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace user_info_webmvc
{
    /// <summary>
    /// Program Startup.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// Builds the web host.
        /// </summary>
        /// <returns>The web host.</returns>
        /// <param name="args">Arguments.</param>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
