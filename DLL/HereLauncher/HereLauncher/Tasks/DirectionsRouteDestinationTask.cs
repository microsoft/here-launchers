using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Device.Location;
using System.Net;


/// <summary>
/// The DirectionsRouteDestinationTask allows you to start the Maps application and to show a route in the map. 
/// There is only one required parameter to be defined, and it is the Destination coordinate to where the route is going to be created to.
/// </summary>
/// <param name="Destination">Destination location (required)</param>
/// <param name="Origin">Departure location</param>
/// <param name="Mode">Preferred route mode</param>
/// 


namespace Nokia.Phone.HereLaunchers
{
    /// <summary>
    /// Provides a simple way to show route from selected originl to the selected destination with Maps application
    /// </summary>
    /// 
    public sealed class DirectionsRouteDestinationTask : TaskBase
    {
        /// <summary>
        /// Gets or sets the Destination coordinates.
        /// </summary>
        /// <value>
        /// The Destination coordinates as GeoCoordinate.
        /// </value>
        public GeoCoordinate Destination { get; set; }


        /// <summary>
        /// Gets or sets the Origin GeoCoordinate.
        /// </summary>
        /// <value>
        /// The Origin ccordinates as GeoCoordinate.
        /// </value>
        public GeoCoordinate Origin { get; set; }


        /// <summary>
        /// Gets or sets the Mode for the route.
        /// </summary>
        /// <value>
        /// The mode for the route.
        /// </value>
        public RouteMode Mode { get; set; }


        /// <summary>
        ///   Initializes a new instance of the DirectionsRouteDestinationTask class
        /// </summary>
        public DirectionsRouteDestinationTask(): base()
        {
            // Set default values
            Mode = RouteMode.Smart;
        }

        /// <summary>
        /// Shows Nokia Maps with the route
        /// </summary>
        public void Show()
        {
            if (this.Destination != null)
            {
                string latStr = this.Destination.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                string lonStr = this.Destination.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture);

                string UrlToUse = "directions://v2.0/route/destination/?latlon=" + latStr + "," + lonStr;

                if (this.Origin != null)
                {
                    string OriLatStr = this.Origin.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    string OriLonStr = this.Origin.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture);

                    UrlToUse = UrlToUse + "&origin.latlon=" + OriLatStr + "," + OriLonStr;
                }

                /* These are only available for Nokia */
                if (this.Mode != RouteMode.Unknown)
                {
                    switch (this.Mode)
                    {
                        case RouteMode.Car:
                            UrlToUse = UrlToUse + "&mode=car";
                            break;
                        case RouteMode.Pedestrian:
                            UrlToUse = UrlToUse + "&mode=pedestrian";
                            break;
                        case RouteMode.PublicTransport:
                            UrlToUse = UrlToUse + "&mode=publicTransport";
                            break;
                        case RouteMode.Smart:
                        // Smart is default, so we dont need to tell to use it..
                        default:
                            break;
                    }
                }

                this.Launch(new Uri(UrlToUse));
            }
            else
            {
                throw new InvalidOperationException("Please set coordinate for the Destination before calling Show()");
            }
        }
    }
}
