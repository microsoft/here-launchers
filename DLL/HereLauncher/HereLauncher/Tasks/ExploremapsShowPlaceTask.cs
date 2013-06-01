using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Device.Location;
using System.Net;


/// <summary>
/// The ExploremapsShowPlaceTask allows you to start the Maps application with map centered to a place shown in the map. 
/// The place Location must be defined, and optionally it can have Title string as well as the visible map area can be limited with Zoom value supplied.
/// </summary>
/// <param name="Location">Location coordinate for the place(required) </param>
/// <param name="Title">Title to be used with the place</param>
/// <param name="Zoom">Zoom level for the map view. Allowed values from 1.0 to 20.0</param>
/// 
namespace Nokia.Phone.HereLaunchers
{
    public sealed class ExploremapsShowPlaceTask : TaskBase
    {
        /// <summary>
        /// Gets or sets the Location coordinates.
        /// </summary>
        /// <value>
        /// The Location coordinate as GeoCoordinate.
        /// </value>
        public GeoCoordinate Location { get; set; }

        /// <summary>
        /// Gets or sets the Title string for the place.
        /// </summary>
        /// <value>
        /// The Title string to be used with the place.
        /// </value>
        public string Title { get; set; }

        /// Gets or sets the ZoomLevel value.
        /// </summary>
        /// <value>
        /// The ZoomLevel value. This is not available for Nokia 
        /// </value>
        public double Zoom { get; set; }

        /// <summary>
        /// Shows Nokia Maps application with the place as set with the attributes
        /// </summary>
        public void Show()
        {
            if (this.Location != null)
            {
                string latStr = this.Location.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                string lonStr = this.Location.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture);

                string UrlToUse = "explore-maps://v2.0/show/place/?latlon=" + latStr + "," + lonStr;

                if (this.Zoom > 1 && this.Zoom < 21)
                {
                    string zomStr = this.Zoom.ToString(System.Globalization.CultureInfo.InvariantCulture);

                    UrlToUse = UrlToUse + "&map.zoom=" + zomStr;
                }

                if (!string.IsNullOrEmpty(this.Title))
                {
                    string encodedName = Uri.EscapeDataString(this.Title);
                    UrlToUse = UrlToUse + "&title=" + encodedName;
                }

                this.Launch(new Uri(UrlToUse));
            }
            else
            {
                throw new InvalidOperationException("Please set an location coordinates for the place before calling Show()");
            }
        }
    }
}
