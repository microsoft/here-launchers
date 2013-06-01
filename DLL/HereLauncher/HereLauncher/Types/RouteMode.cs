using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nokia.Phone.HereLaunchers
{
    /// <summary>
    /// Defines the mode for routing mode to be used with map directions
    /// </summary>

    public enum RouteMode
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Smart
        /// </summary>
        Smart = 1,

        /// <summary>
        /// Pedestrian
        /// </summary>
        Pedestrian = 2,

        /// <summary>
        /// Car
        /// </summary>
        Car = 3,
        /// <summary>
        /// PublicTransport
        /// </summary>
        PublicTransport = 4
    }
}