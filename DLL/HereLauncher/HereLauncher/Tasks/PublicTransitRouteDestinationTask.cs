using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Device.Location;
using System.Net;

/// <summary>
/// The PublicTransitRouteDestinationTask allows you to start the Public Transit application with journeys view active.
/// </summary>
/// <param name="Destination">Destination coordinate for the journey(required)</param>
/// <param name="DestinationTitle">Destination title to be used with journey route.</param>
/// <param name="Origin">Origin coordinate for the journey.</param>
/// <param name="OriginTitle">Origin title to be used with journey route.</param>
/// <param name="ArrivalTime">Desired arrival time to the destination.</param>
/// <param name="DepartureTime">Desired departure time from the origin.</param>
/// 


namespace Nokia.Phone.HereLaunchers
{
    public sealed class PublicTransitRouteDestinationTask : TaskBase
    {
        /// <summary>
        /// Gets or sets the Destination coordinates.
        /// </summary>
        /// <value>
        /// The Destination coordinates as GeoCoordinate.
        /// </value>
        public GeoCoordinate Destination { get; set; }

        /// <summary>
        /// Gets or sets the Destination Title string.
        /// </summary>
        /// <value>
        /// The Destination Title as string.
        /// </value>
        public string DestinationTitle { get; set; }

        /// <summary>
        /// Gets or sets the Origin Origin.
        /// </summary>
        /// <value>
        /// The Origin Origin as GeoCoordinate.
        /// </value>
        public GeoCoordinate Origin { get; set; }

        /// <summary>
        /// Gets or sets the Origin Title string.
        /// </summary>
        /// <value>
        /// The Origin Title as string.
        /// </value>
        public string OriginTitle { get; set; }

        /// <summary>
        /// Gets or sets the ArrivalTime .
        /// </summary>
        /// <value>
        /// The Arrival Time as DateTime.
        /// </value>
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// Gets or sets the DepartureTime.
        /// </summary>
        /// <value>
        /// The Departure Time as DateTime.
        /// </value>
        public DateTime DepartureTime { get; set; }

        /// <summary>
        ///   Initializes a new instance of the PublicTransitRouteDestinationTask class
        /// </summary>
        public PublicTransitRouteDestinationTask(): base()
        {
            // Set default values
            ArrivalTime = new DateTime(0);
            DepartureTime = new DateTime(0);
        }
        /// <summary>
        /// Shows Nokia Maps with the route
        /// </summary>
        public void Show()
        {
            if ((this.Destination != null))
            {
                string latStr = this.Destination.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                string lonStr = this.Destination.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture);

                string UrlToUse = "public-transit://v2.0/route/destination/?latlon=" + latStr + "," + lonStr;;

                if (!string.IsNullOrEmpty(this.DestinationTitle))
                {
                    string encodedDetination = Uri.EscapeDataString(this.DestinationTitle);
                    UrlToUse = UrlToUse + "&title=" + encodedDetination;
                }

                if (this.Origin != null)
                {
                    string OrilatStr = this.Origin.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    string OrilonStr = this.Origin.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture);

                    UrlToUse = UrlToUse + "&origin.latlon=" + OrilatStr + "," + OrilonStr;

                    if (!string.IsNullOrEmpty(this.OriginTitle))
                    {
                        string encodedOrigin = Uri.EscapeDataString(this.OriginTitle);
                        UrlToUse = UrlToUse + "&origin.title=" + encodedOrigin;
                    }
                }

                if (this.DepartureTime.CompareTo(new DateTime(0)) != 0)
                {
                    UrlToUse = UrlToUse + "&departureTime=" + this.DepartureTime.ToString("s");
                }

                if (this.ArrivalTime.CompareTo(new DateTime(0)) != 0)
                {
                    UrlToUse = UrlToUse + "&arrivalTime=" + this.ArrivalTime.ToString("s");
                }

                this.Launch(new Uri(UrlToUse));
            }
            else
            {
                throw new InvalidOperationException("Please set the Destination before calling Show()");
            }
        }
    }
}
